using Microsoft.AspNetCore.Mvc;

namespace _3DModelMax.Host.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("upload")]
        [HttpPost]
        public IActionResult UploadModel(IFormFile _3DModelDTO)
        {
            using (var fileStream = new FileStream(Path.Combine(_3DModelDTO.Name), FileMode.Create, FileAccess.Write))
            {
                _3DModelDTO.CopyTo(fileStream);
            }

            return RedirectToAction("Index");
        }
    }
}
