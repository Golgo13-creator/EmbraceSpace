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
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var service = new SpaceShipService();
            service.CreateSpaceShip(model);
            return RedirectToAction("Index");
        }
    }
}