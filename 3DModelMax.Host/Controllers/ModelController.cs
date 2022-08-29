using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Interfaces;
using _3DModelMax.Persistence.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace _3DModelMax.Host.Controllers
{
    [Route("api/models")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private IModelService _modelService;
        private IAuthorRepository<Author> _authorRepository;

        public ModelController(IModelService modelService, IAuthorRepository<Author> authorRepository)
        {
            _modelService = modelService;
            _authorRepository = authorRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateModel([FromForm] _3DModelDTO objModel)
        {
            if (!ModelState.IsValid || objModel.File.Length == 0)
            {
                return BadRequest();
            }

            if (objModel.AuthorId <= 0 
                || !_authorRepository.GetAuthorsList().Result.Any(a => a.Id > objModel.AuthorId) 
                || _authorRepository.GetAuthorById(objModel.AuthorId).Result is null) 
            {
                return BadRequest();
            }

            await _modelService.CreateModel(objModel);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateModel([FromForm] _3DModelUpdateDTO objModel)
        {
            if (!ModelState.IsValid || objModel.File.Length == 0)
            {
                return BadRequest();
            }

            if (objModel.AuthorId <= 0 
                ||  !_authorRepository.GetAuthorsList().Result.Any(a => a.Id > objModel.AuthorId) 
                || _authorRepository.GetAuthorById(objModel.AuthorId).Result is null)
            {
                return BadRequest();
            }

            await _modelService.UpdateModel(objModel);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteModelById(int id)
        {
            if (!ModelState.IsValid )
            {
                return BadRequest();
            }

            await _modelService.DeleteModelById(id);
            return Ok();
        }
    }
}
