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
    [Authorize(Roles = "Admin, User")]
    public class TicketsController : Controller
    {
        private readonly ITicketRepository repository;
        private readonly IPassengersRepository repository_p;
        private readonly IToursRepository repository_t;

        public TicketsController(ITicketRepository objIrepository, IPassengersRepository objIrepository_p
            ,IToursRepository objIRepository_t)
        {
            repository = objIrepository;
            repository_p = objIrepository_p;
            repository_t = objIRepository_t;
        }

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = repository.All.Include(t => t.Passenger).Include(t => t.Tour);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = repository.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Buy()
        {
            ViewBag.Passenger_Id = new SelectList(repository_p.All, "Id", "Name");
            ViewBag.Trip_Id = new SelectList(repository_t.All, "TourId", "TourId");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy([Bind(Include = "Id,BookingTime,IsBlocked,Trip_Id,Passenger_Id,Price")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(ticket);
                repository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Passenger_Id = new SelectList(repository_p.All, "Id", "Name", ticket.Passenger_Id);
            ViewBag.Trip_Id = new SelectList(repository_t.All, "TourId", "Departure", ticket.Trip_Id);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = repository.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.Passenger_Id = new SelectList(repository_p.All, "Id", "Name", ticket.Passenger_Id);
            ViewBag.Trip_Id = new SelectList(repository_t.All, "TourId", "Departure", ticket.Trip_Id);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookingTime,IsBlocked,Trip_Id,Passenger_Id,Price")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                repository.Update(ticket);
                repository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Passenger_Id = new SelectList(repository_p.All, "Id", "Name", ticket.Passenger_Id);
            ViewBag.Trip_Id = new SelectList(repository_t.All, "TourId", "Departure", ticket.Trip_Id);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = repository.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = repository.Find(id);
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetTicketPrice(string tourId)
        {
            int Id = Convert.ToInt32(tourId);

            var price = from cst in repository_t.All
                            where cst.TourId == Id
                            select cst;

            List<decimal> pList = new List<decimal>();
            foreach (var item in price)
            {
                pList.Add(item.Price);
            }
            return Json(pList, JsonRequestBehavior.AllowGet);
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
