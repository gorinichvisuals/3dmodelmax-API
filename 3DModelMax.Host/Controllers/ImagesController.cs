using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        [Route("{id:int}")]
        public async Task<IActionResult> AddImages([FromBody][Required] ICollection<ImageDTO> images, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(await _imageService.AddImages(images, id))                                                   
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}