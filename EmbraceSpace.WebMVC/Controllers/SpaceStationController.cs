using EmbraceSpace.Models;
using EmbraceSpace.Models.SpaceStationModels;
using EmbraceSpace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbraceSpace.WebMVC.Controllers
{
    [Authorize]
    public class SpaceStationController : Controller
    {
        // GET: SpaceStation
        public ActionResult Index()
        {
            var service = new SpaceStationService();
            var model = service.GetAllSpaceStations();
            return View(model);
        }
        //Get
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SpaceStationCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new SpaceStationService();
            if (service.CreateSpaceStation(model))
            {
                TempData["SaveResult"] = "Your Space Station was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Space Station could not be created.");
            return View(model);
        }
        //Get
        public ActionResult Details(int id)
        {
            var svc = new SpaceStationService();
            var model = svc.GetSpaceStationById(id);
            return View(model);
        }
        //Get
        public ActionResult Edit(int id)
        {
            var service = new SpaceStationService();
            var detail = service.GetSpaceStationById(id);
            var model =
                new SpaceStationEdit
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    MaximumOccupancy = detail.MaximumOccupancy
                };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, SpaceStationEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new SpaceStationService();
            if (service.UpdateSpaceStation(model))
            {
                TempData["SaveResult"] = "Your Space Station was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Space Station could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = new SpaceStationService();
            var model = svc.GetSpaceStationById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteShip(int id)
        {
            var service = new SpaceStationService();
            service.DeleteSpaceStation(id);
            TempData["SaveResult"] = "Your Space Station was deleted.";
            return RedirectToAction("Index");
        }
    }
}