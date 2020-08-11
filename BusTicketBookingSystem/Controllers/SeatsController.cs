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
    public class SeatsController : Controller
    {
        private readonly ISeatsRepository repository;
        private readonly IBusRepository repository_b;
        private readonly IPassengersRepository repository_p;

        public SeatsController(ISeatsRepository objIRepository, IBusRepository objIrepository_b, 
            IPassengersRepository objIrepository_p)
        {
            repository = objIRepository;
            repository_b = objIrepository_b;
            repository_p = objIrepository_p;
        }

        // GET: Seats
        public ActionResult Index()
        {
            var seats = repository.All.Include(s => s.Bus).Include(s => s.Passenger);
            return View(seats.ToList());
        }

        // GET: Seats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = repository.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }

        // GET: Seats/Create
        public ActionResult Create()
        {
            ViewBag.BusId = new SelectList(repository_b.All, "BusId", "NrReg");
            ViewBag.PassengerId = new SelectList(repository_p.All, "Id", "Name");
            return View();
        }

        // POST: Seats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsAvailable,SeatNumber,PassengerId,BusId,Time")] Seat seat)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(seat);
                repository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.BusId = new SelectList(repository_b.All, "BusId", "NrReg", seat.BusId);
            ViewBag.PassengerId = new SelectList(repository_p.All, "Id", "Name", seat.PassengerId);
            return View(seat);
        }

        // GET: Seats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = repository.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusId = new SelectList(repository_b.All, "BusId", "NrReg", seat.BusId);
            ViewBag.PassengerId = new SelectList(repository_p.All, "Id", "Name", seat.PassengerId);
            return View(seat);
        }

        // POST: Seats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsAvailable,SeatNumber,PassengerId,BusId,Time")] Seat seat)
        {
            if (ModelState.IsValid)
            {
                repository.Update(seat);
                repository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.BusId = new SelectList(repository_b.All, "BusId", "NrReg", seat.BusId);
            ViewBag.PassengerId = new SelectList(repository_p.All, "Id", "Name", seat.PassengerId);
            return View(seat);
        }

        // GET: Seats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = repository.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }

        // POST: Seats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seat seat = repository.Find(id);
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
