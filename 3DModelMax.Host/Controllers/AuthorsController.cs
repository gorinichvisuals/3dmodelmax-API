using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3DModelMax.Host.Controllers
{
    [Route("api/authors")]
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

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorCreateDTO author)
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await authorService.CreateAuthor(author);
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
