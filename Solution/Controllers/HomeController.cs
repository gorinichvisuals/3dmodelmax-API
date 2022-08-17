using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace _3DModelMax.Host.Controllers
{
    public class HomeController : Controller
    {
        [Obsolete]
        private IHostingEnvironment _environment;

        [Obsolete]
        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadModel(IFormFile file)
        {
            using (var fileStream = new FileStream(Path.Combine(file.Name), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }

            return RedirectToAction("Index");
        }
    }
}
