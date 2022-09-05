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
        private ILogger<ModelController> _logger;

        public ModelController(IModelService modelService, ILogger<ModelController> logger)
        {
            _modelService = modelService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateModel([FromForm] _3DModelDTO objModel)
        {
            try
            {
                if (!ModelState.IsValid || objModel.File.Length == 0)
                {
                    return BadRequest();
                }

                if(await _modelService.CreateModel(objModel))
                {
                    _logger.LogInformation("Model is created: " + objModel);
                    return Ok();
                }
               
                return BadRequest();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to create 3D model");
                return StatusCode(500, "Failed to create 3D model");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateModel([FromForm] _3DModelUpdateDTO objModel)
        {
            try 
            {
                if (!ModelState.IsValid || objModel.File.Length == 0)
                {
                    return BadRequest();
                }

                await _modelService.UpdateModel(objModel);
                _logger.LogInformation("Model is updated: " + objModel);

                return Ok();
            }            
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to update 3D model");
                return StatusCode(500, "Failed to update 3D model");
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteModelById(int id)
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _modelService.DeleteModelById(id);
                _logger.LogInformation("Model is deleted: " + id);

                return Ok();

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to delete 3D model");
                return StatusCode(500, "Failed to delete 3D model");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetModel(int id)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    return BadRequest();                   
                }
               
                await _modelService.GetModelById(id);
                _logger.LogInformation("Model found: " + id);

                return Ok(); 
            }
            catch(Exception exception)
            {
                _logger.LogError(exception, "Failed to get 3D model");
                return StatusCode(500, "Failed to get 3D model");
            }
        }
    }
}
