using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
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
        public IActionResult CreateModel([FromForm] _3DModelDTO objModel)
        {
            if (!ModelState.IsValid || objModel.File.Length == 0)
            {
                return BadRequest();
            }

            _modelService.CreateModel(objModel);
            return Ok();
        }
    }
}
