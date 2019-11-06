using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Repositories
{
    public class ToursRepository : IToursRepository
    {
        TicketBookingModelEntities _db;

        public ToursRepository(TicketBookingModelEntities db)
        {
            this._db = db;
        }

        public IQueryable<Tour> All
        {
            get { return _db.Tours; }
        }

        public void Delete(int id)
        {
            var tour = _db.Tours.Find(id);
            _db.Tours.Remove(tour);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Tour Find(int? id)
        {
            Tour tour = new Tour();
            tour = _db.Tours.Where(p => p.TourId == id).FirstOrDefault();
            return tour;
        }

        public void Insert(Tour tour)
        {
            _db.Tours.Add(tour);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Tour tour)
        {
            _db.Entry(tour).State = System.Data.Entity.EntityState.Modified;
        }

        public void Reserve(int id)
        {
            Tour tour = _db.Tours.Find(id);
            if (tour != null)
            {
                //return View(tour);
                _db.Tours.Add(tour);
            }
            //return HttpNotFound();
        }

    }
}
