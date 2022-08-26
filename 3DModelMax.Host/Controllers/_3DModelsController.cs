﻿using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Services;
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

        public async Task<IActionResult> IndexAsync()
        {
            return View(await db.Get3DmodelsList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(_3DModelDTO _3dmodel)
        {
            if (ModelState.IsValid)
            {
                await db.Create(_3dmodel);
                await db.Save();
                return RedirectToAction("Index");
            }
            return View(_3dmodel);
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            _3DModelDTO _3dmodel = await db.Get3DmodelsById(id);
            return View(_3dmodel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(_3DModelDTO _3dmodel)
        {
            if (ModelState.IsValid)
            {
                await db.Update(_3dmodel);
                await db.Save();
                return RedirectToAction("Index");
            }
            return View(_3dmodel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete3DModelsByIdAsync(int id)
        {
            _3DModelDTO _3dmod = await db.Get3DmodelsById(id);
            return View(_3dmod);
        }

        [HttpPost, ActionName("Delete3DModelsById")]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            await db.Delete3DmodelsById(id);
            return RedirectToAction("Index");
        }
    }
}
