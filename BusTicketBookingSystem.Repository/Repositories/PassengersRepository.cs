using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Repositories
{
    public class PassengersRepository : IPassengersRepository
    {
        TicketBookingModelEntities _db;

        public PassengersRepository(TicketBookingModelEntities db)
        {
            this._db = db;
        }

        public IQueryable<Passenger> All
        {
            get { return _db.Passengers; }
        }

        public void Delete(int id)
        {
            var pas = _db.Passengers.Find(id);
            _db.Passengers.Remove(pas);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Passenger Find(int? id)
        {
            Passenger objPas = new Passenger();
            objPas = _db.Passengers.Where(p => p.Id== id).FirstOrDefault();
            return objPas;
        }

        public void Insert(Passenger p)
        {
            _db.Passengers.Add(p);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Passenger p)
        {
            _db.Entry(p).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
