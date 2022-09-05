using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace _3DModelMax.Host.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private IImageService _imageService;
        private ILogger<ImagesController> _logger;

        public ImagesController(IImageService imageService, ILogger<ImagesController> logger)
        {
            _imageService = imageService;
            _logger = logger;
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

                _logger.LogInformation("Add images: " + images);

                return await _imageService.AddImages(images, id)
                                          ? Ok()
                                          : BadRequest();
            }
            catch (Exception exception) 
            {
                _logger.LogError(exception, "Failed to create images");
                return StatusCode(500, "Failed to create images"); 
            }
        }
    }
}