using EmbraceSpace.Models.SpaceShipModels;
using EmbraceSpace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbraceSpace.WebMVC.Controllers
{
    [Authorize]
    public class SpaceShipController : Controller
    {
        // GET: SpaceShip
        public ActionResult Index()
        {
            var service = new SpaceShipService();
            var model = service.GetAllSpaceShips();
            return View(model);
        }
        //Get
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SpaceShipCreate model)
        {
            if(!ModelState.IsValid) return View(model);
            var service = new SpaceShipService();
            if(service.CreateSpaceShip(model))
            {
                TempData["SaveResult"] = "Your SpaceShip was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "SpaceShip could not be created.");
            return View(model);
        }
        //Get
        public ActionResult Details(int id)
        {
            var svc = new SpaceShipService();
            var model = svc.GetSpaceShipById(id);
            return View(model);
        }
        //Get
        public ActionResult Edit(int id)
        {
            var service = new SpaceShipService();
            var detail = service.GetSpaceShipById(id);
            var model =
                new SpaceShipEdit
                {
                    Id = detail.Id,
                    ShipName = detail.ShipName,
                    CrewCapacity = detail.CrewCapacity
                };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, SpaceShipEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new SpaceShipService();
            if(service.UpdateSpaceShip(model))
            {
                TempData["SaveResult"] = "Your ship was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your ship could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = new SpaceShipService();
            var model = svc.GetSpaceShipById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteShip(int id)
        {
            var service = new SpaceShipService();
            service.DeleteSpaceShip(id);
            TempData["SaveResult"] = "Your ship was deleted.";
            return RedirectToAction("Index");
        }
    }
}