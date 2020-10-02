using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Models;
using BusTicketBookingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BusTicketBookingSystem.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class ToursController : Controller
    {
        private readonly IToursRepository repository;
        private readonly ICityRepository repository_c;
        private readonly IBusRepository repository_b;

        public ToursController(IToursRepository objIrepository, ICityRepository objIrepository_c
            , IBusRepository objIrepository_b)
        {
            repository = objIrepository;
            repository_c = objIrepository_c;
            repository_b = objIrepository_b;
        }     

        private TicketBookingModelEntities db = new TicketBookingModelEntities();

        // GET: Tours
        [Authorize]
        public ActionResult Index()
        {
            return View(repository.All.ToList());
        }
     

        // GET: Tours/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = repository.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Tours/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(repository_c.All, "CityId", "CityId");
            ViewBag.BusId = new SelectList(repository_b.All, "BusId", "BusId");
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "TourId,TourDate,CityId,Departure,Arrival,BusId,SeatsAvailable,Price")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(tour);
                repository.Save();
                return RedirectToAction("Index");
            }

            return View(tour);
        }

        // GET: Tours/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = repository.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "TourId,TourDate,CityId,Departure,Arrival,BusId,SeatsAvailable,Price")] Tour tour)
        {

            if (ModelState.IsValid)
            {
                repository.Update(tour);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(tour);
        }

        // GET: Tours/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = repository.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }

        //
        [Authorize]
        public ActionResult Reserve(int id)
        {
            //Tour tour = db.Tours.Find(id);
            Tour tour = repository.Find(id);
            if (tour != null)
            {
                return View(tour);
            }
            return HttpNotFound();
        }

        [HttpPost, ActionName("Reserve")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CompleteBooking(int id)
        {
            Reservation res = new Reservation();
            //Tour tour = db.Tours.Find(id);
            Tour tour = repository.Find(id);
         var r =  tour.NewReservation(tour.TourId, User.Identity.Name);
            var book = db.Reservations.OrderByDescending(x => x.TourId).First(i => i.TourId == id && i.UserName == User.Identity.Name);
            if (r)
            {
                 res.ConfirmReservation(book, book.UserName);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", r.ToString());
            return View(tour);
        }
        //

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
