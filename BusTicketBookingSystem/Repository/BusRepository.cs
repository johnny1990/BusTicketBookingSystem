using BusTicketBookingSystem.Contracts;
using BusTicketBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTicketBookingSystem.Repository
{
    public class BusRepository : IBusRepository
    {
        TicketBookingModelEntities _db;

        public BusRepository(TicketBookingModelEntities db)
        {
            this._db = db;
        }

        public IQueryable<Bus> All
        {
            get { return _db.Buses; }
        }

        public void Delete(int id)
        {
            var bus = _db.Buses.Find(id);
            _db.Buses.Remove(bus);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Bus Find(int? id)
        {
            Bus objBus = new Bus();
            objBus = _db.Buses.Where(p => p.BusId == id).FirstOrDefault();
            return objBus;
        }

        public void Insert(Bus bus)
        {
            _db.Buses.Add(bus);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Bus bus)
        {
            _db.Entry(bus).State = System.Data.Entity.EntityState.Modified;
        }
    }
}