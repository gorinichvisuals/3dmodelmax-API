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

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
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
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to create this entity");
            }           
        }
    }
}
