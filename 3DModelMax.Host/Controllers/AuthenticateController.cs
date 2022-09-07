﻿using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Interfaces;
using _3DModelMax.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _3DModelMax.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        private ILogger<AuthorsController> _logger;
        private readonly IAuthorRepository<Author> _authorRepository;

        public AuthenticateController(IAuthenticateService authenticateService, 
                                      ILogger<AuthorsController> logger, 
                                      IAuthorRepository<Author> authorRepository)
        {
            _authenticateService = authenticateService;
            _logger = logger;
            _authorRepository = authorRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO authorRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var token = await _authenticateService.Login(authorRequest);
                var author = await _authorRepository.GetAuthor(authorRequest.NickName);

                if (!_authenticateService.VerifyPasswordHash(authorRequest.Password, author.PasswordHash, author.PasswordSalt))
                {
                    return BadRequest("Wrong password.");
                }

                if (token == null)
                {
                    return BadRequest(new { message = "Author not found" });
                }

                return Ok(token);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to login author");
                return StatusCode(500, "Failed to login author");
            }
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminAuthorize()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var currentUser = GetCurrentUser();
                //var currentUser = await _authenticateService.Login(authorRequest);

                if (currentUser == null)
                {
                    return BadRequest(new { message = "You are not admin" });
                }

                return Ok(currentUser);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to authorize admin");
                return StatusCode(500, "Failed to authorize admin");
            }
        }

        [HttpGet("author")]
        [Authorize(Roles = "Author")]
        public IActionResult AuthorAuthorize()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var currentUser = GetCurrentUser();

                //var currentUser = await _authenticateService.Login(authorRequest);

                if (currentUser == null)
                {
                    return BadRequest(new { message = "You are not author" });
                }

                return Ok(currentUser);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to authorize author");
                return StatusCode(500, "Failed to authorize author");
            }
        }
        private Author GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new Author
                {
                    NickName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
        /*
        public async Task<IActionResult> Logout() 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
            }
            catch(Exception exception)
            {
                _logger.LogError(exception, "Failed to logout author");
                return StatusCode(500, "Failed to logout author");
            }
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        */
    }
}
