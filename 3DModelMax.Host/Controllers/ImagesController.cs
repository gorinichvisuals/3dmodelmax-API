using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using static System.Net.WebRequestMethods;

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
            try 
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                return await _imageService.AddImages(images, id)
                                          ? Ok()
                                          : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to create this entity");
            }
        }
    }
}