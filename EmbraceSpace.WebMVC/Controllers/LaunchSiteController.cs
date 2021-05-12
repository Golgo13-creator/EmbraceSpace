using EmbraceSpace.Models.LaunchSiteModels;
using EmbraceSpace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbraceSpace.WebMVC.Controllers
{
    [Authorize]
    public class LaunchSiteController : Controller
    {
        // GET: LaunchSite
        public ActionResult Index()
        {
            var service = new LaunchSiteService();
            var model = service.GetAllLaunchSites();
            return View(model);
        }
        //Get
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LaunchSiteCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new LaunchSiteService();
            if (service.CreateLaunchSite(model))
            {
                TempData["SaveResult"] = "Your Launch Site was created!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Launch Site could not be created.");
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
            var service = new LaunchSiteService();
            var detail = service.GetLaunchSiteById(id);
            var model =
                new LaunchSiteEdit
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    Location = detail.Location
                };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, LaunchSiteEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new LaunchSiteService();
            if (service.UpdateLaunchSite(model))
            {
                TempData["SaveResult"] = "Your Launch Site was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Launch Site could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = new LaunchSiteService();
            var model = svc.GetLaunchSiteById(id);
            return View(model);
        }
    }
}