using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3DModelMax.Host.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromForm] AuthorCreateDTO author)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(); 
            }

            await authorService.CreateAuthor(author);
            return Ok();
        }
    }
}
