using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _3DModelMax.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService authorService;
        private ILogger<AuthorsController> _logger;

        public AuthorsController(IAuthorService authorService, ILogger<AuthorsController> logger)
        {
            this.authorService = authorService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Registration([FromBody] AuthorRegistrationDTO author)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await authorService.AuthorRegistration(author);
                _logger.LogInformation("Author is created: " + author);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to create author");
                return StatusCode(500, "Failed to create author");
            }
        }
    }
}
