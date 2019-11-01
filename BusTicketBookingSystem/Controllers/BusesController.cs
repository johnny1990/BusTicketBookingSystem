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

        public BusesController(IBusRepository objIrepository)
        {
            repository = objIrepository;
        }

        public BusesController()
        {

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
            return View();
        }

        // POST: Buses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusId,NrReg,NrSeats")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(bus);
                repository.Save();
                return RedirectToAction("Index");
            }

            return View(bus);
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
            return View(bus);
        }

        // POST: Buses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusId,NrReg,NrSeats")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                repository.Update(bus);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(bus);
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
            return View(bus);
        }

        // POST: Buses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
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
