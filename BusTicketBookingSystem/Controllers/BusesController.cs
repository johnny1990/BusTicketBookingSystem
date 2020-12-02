using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Repository.Interfaces;

namespace BusTicketBookingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BusesController : Controller
    {
        private readonly IBusRepository repository;
        private readonly IDriversRepository repository_d;

        public BusesController(IBusRepository objIrepository, IDriversRepository objIrepository_d)
        {
            repository = objIrepository;
            repository_d = objIrepository_d;
        }

        // GET: Buses
        public ActionResult Index()
        {
            return View(repository.All.ToList());
        }

        // GET: Buses/Details/5
        public ActionResult Details(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = repository.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // GET: Buses/Create
        public ActionResult Create()
        {
            ViewBag.DriverId = new SelectList(repository_d.All, "DriverId", "DriverId");
            return View();
        }

        [HttpPost]
        public JsonResult InsertBus(Bus bus)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(bus);
                repository.Save();
            }

            return Json(bus);
        }

        // GET: Buses/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = repository.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverId = new SelectList(repository_d.All, "DriverId", "DriverId");
            ViewBag.Id = id;
            return View(bus);
        }

        [HttpPost]
        public JsonResult UpdateBus(Bus bus)
        {
            if (ModelState.IsValid)
            {
                repository.Update(bus);
                repository.Save();
                return Json("Ok");
            }
            else
                return Json("Not ok");
        }

        // GET: Buses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = repository.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = id;
            return View(bus);
        }

        [HttpPost]
        public JsonResult DeleteBus(int id)
        {
            repository.Delete(id);
            repository.Save();

            return Json("");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
