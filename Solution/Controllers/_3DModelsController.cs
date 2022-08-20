using _3DModelMax.Host.Models;
using _3DModelMax.Persistence.Models;
using _3DModelMax.Persistence.ServicesDTO;
using Microsoft.AspNetCore.Mvc;

namespace _3DModelMax.Host.Controllers
{
    public class _3DModelsController : Controller
    {
        IRepository<_3DModelDTO> db;

        public _3DModelsController(IRepository<_3DModelDTO> _3DModel)
        {
            db = _3DModel;
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
        public ActionResult Create(_3DModelDTO _3dmodel)
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
            _3DModelDTO _3dmodel = db.Get3DmodelsById(id);
            return View(_3dmodel);
        }

        [HttpPost]
        public ActionResult Edit(_3DModelDTO _3dmodel)
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
            _3DModelDTO _3dmod = db.Get3DmodelsById(id);
            return View(_3dmod);
        }

        [HttpPost, ActionName("Delete3DmodelsById")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete3DmodelsById(id);
            return RedirectToAction("Index");
        }
    }
}
