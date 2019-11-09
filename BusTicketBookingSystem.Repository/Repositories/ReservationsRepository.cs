using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTicketBookingSystem.Repository.Repositories
{
    public class ReservationsRepository : IReservationsRepository
    {
        TicketBookingModelEntities _db;

        public ReservationsRepository(TicketBookingModelEntities db)
        {
            this._db = db;
        }

        public IQueryable<Reservation> All
        {
            get { return _db.Reservations; }
        }

        public void Delete(int id)
        {
            var res = _db.Reservations.Find(id);
            _db.Reservations.Remove(res);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Reservation Find(int? id)
        {
            Reservation objRes = new Reservation();
            objRes = _db.Reservations.Where(p => p.ReservationId == id).FirstOrDefault();
            return objRes;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Reservation res)
        {
            _db.Entry(res).State = System.Data.Entity.EntityState.Modified;
        }
    }
}