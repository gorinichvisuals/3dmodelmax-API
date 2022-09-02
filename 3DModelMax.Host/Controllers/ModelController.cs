using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
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

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateModel([FromForm] _3DModelDTO objModel)
        {
            if (!ModelState.IsValid || objModel.File.Length == 0)
            {
                return BadRequest();
            }

            return await _modelService.
                                    CreateModel(objModel) 
                                    ? Ok() 
                                    : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateModel([FromForm] _3DModelUpdateDTO objModel)
        {
            if (!ModelState.IsValid || objModel.File.Length == 0)
            {
                return BadRequest();
            }

            await _modelService.UpdateModel(objModel);
           
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteModelById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _modelService.DeleteModelById(id);
            return Ok();
        }
    }
}
