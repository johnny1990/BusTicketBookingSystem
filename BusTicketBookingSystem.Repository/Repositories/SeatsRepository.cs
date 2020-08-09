using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Repositories
{
    public class SeatsRepository : ISeatsRepository
    {
        TicketBookingModelEntities _db;

        public SeatsRepository(TicketBookingModelEntities db)
        {
            this._db = db;
        }

        public IQueryable<Seat> All
        {
            get { return _db.Seats; }
        }

        public void Delete(int id)
        {
            var bus = _db.Seats.Find(id);
            _db.Seats.Remove(bus);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Seat Find(int? id)
        {
            Seat objBus = new Seat();
            objBus = _db.Seats.Where(p => p.BusId == id).FirstOrDefault();
            return objBus;
        }

        public void Insert(Seat s)
        {
            _db.Seats.Add(s);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Seat s)
        {
            _db.Entry(s).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
