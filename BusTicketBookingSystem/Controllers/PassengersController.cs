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
    public class PassengersController : Controller
    {

        private readonly IPassengersRepository repository;

        public PassengersController( IPassengersRepository objIrepository)
        {
            repository = objIrepository;
        }

        PassengersServiceReference.PassengersServiceClient srv = new PassengersServiceReference.PassengersServiceClient();

        // GET: Passengers
        public ActionResult Index()
        {
            List<Passenger> lstRecord = new List<Passenger>();
            var lst = srv.GetAllPassengers();

            foreach (var item in lst)
            {
                Passenger p = new Passenger();
                p.Id = item.Id;
                p.Name = item.Name;
                p.Blocked = p.Blocked;
                lstRecord.Add(p);
            }

            return View(lstRecord);
        }

        // GET: Passengers/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger pass = srv.GetPassengerById(id);
            if (pass == null)
            {
                return HttpNotFound();
            }
            return View(pass);
        }

        // GET: Passengers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Blocked")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                Passenger p = new Passenger();
                p.Id = passenger.Id;
                p.Name = passenger.Name;
                p.Blocked = passenger.Blocked;
                srv.AddPassenger(p.Name, p.Blocked);
                return RedirectToAction("Index");
            }

            return View(passenger);
        }

        // GET: Passengers/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger pass = srv.GetPassengerById(id);
            if (pass == null)
            {
                return HttpNotFound();
            }
            return View(pass);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Blocked")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                Passenger p = new Passenger();
                p.Id = passenger.Id;
                p.Name = passenger.Name;
                p.Blocked = passenger.Blocked;

                int val = srv.UpdatePassenger(p.Id, p.Name, p.Blocked);
                if (val > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(passenger);
        }

        // GET: Passengers/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger pass = srv.GetPassengerById(id);
            if (pass == null)
            {
                return HttpNotFound();
            }
            return View(pass);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int val = srv.DeletePassengerById(id);
            if (val > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
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
