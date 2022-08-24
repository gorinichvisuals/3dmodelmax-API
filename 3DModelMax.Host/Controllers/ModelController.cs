using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace _3DModelMax.Host.Controllers
{
    [Route("api/models")]
    [ApiController]
    public class CreateModelController : ControllerBase
    {
        private IModelService _modelService;

        public CreateModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost]
        public IActionResult CreateModel([FromForm] _3DModelDTO objModel)
        {
            _modelService.CreateModel(objModel);
            return Ok();
        }
    }
}
