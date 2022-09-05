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

                _logger.LogInformation("Model is created: " + objModel);

                return await _modelService.CreateModel(objModel)
                                          ? Ok()
                                          : BadRequest();
            }
            catch (Exception exception)
            {
                _logger.LogError("Internal error 500 {0}", exception);
                return StatusCode(500, "Failed to create this 3D model");
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

                _logger.LogInformation("Model is updated: " + objModel);

                await _modelService.UpdateModel(objModel);
                    return Ok();
            }            
            catch (Exception exception)
            {
                _logger.LogError("Internal error 500 {0}", exception);
                return StatusCode(500, "Failed to update this 3D model");
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

                _logger.LogInformation("Model is deleted: " + id);

                await _modelService.DeleteModelById(id);
                    return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError("Internal error 500 {0}", exception);
                return StatusCode(500, "Failed to delete this 3D model");
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

                _logger.LogInformation("Model not found: " + id);

                await _modelService.GetModelById(id);
                    return Ok();
            }
            catch(Exception exception)
            {
                _logger.LogError("Internal error 500 {0}", exception);
                return StatusCode(500, "Failed to get this 3D model");
            }
        }
    }
}
