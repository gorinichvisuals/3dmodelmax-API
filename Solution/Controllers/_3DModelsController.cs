using _3DModelMax.Host.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace _3DModelMax.Host.Controllers
{
    public class _3DModelsController : Controller
    {
        private readonly IRepository<_3DModels> db;

        public _3DModelsController()
        {
            db = new SQL3DModelsRepository();
        }

        public ActionResult Index()
        {
            return View(db.Get3DmodelsList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(_3DModels _3dmodel)
        {
            if (ModelState.IsValid)
            {
                db.Create(_3dmodel);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(_3dmodel);
        }

        public ActionResult Edit(int id)
        {
            _3DModels _3dmodel = db.Get3DmodelsById(id);
            return View(_3dmodel);
        }

        [HttpPost]
        public ActionResult Edit(_3DModels _3dmodel)
        {
            if (ModelState.IsValid)
            {
                db.Update(_3dmodel);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(_3dmodel);
        }

        [HttpGet]
        public ActionResult Delete3DmodelsById(int id)
        {
            _3DModels _3dmod = db.Get3DmodelsById(id);
            return View(_3dmod);
        }

        [HttpPost, ActionName("Delete3DmodelsById")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete3DmodelsById(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
