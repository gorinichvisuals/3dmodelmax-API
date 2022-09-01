using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3DModelMax.Host.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> AddImages([FromForm] ImageDTO image)
        {
            if (!ModelState.IsValid || image.Files.Count == null)
            {
                return BadRequest();
            }

            if(await _imageService.AddImages(image))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}