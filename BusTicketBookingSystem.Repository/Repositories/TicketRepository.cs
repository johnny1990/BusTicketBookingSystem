using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        TicketBookingModelEntities _db;

        public TicketRepository(TicketBookingModelEntities db)
        {
            this._db = db;
        }

        public IQueryable<Ticket> All
        {
            get { return _db.Tickets; }
        }

        public void Delete(int id)
        {
            var tour = _db.Tickets.Find(id);
            _db.Tickets.Remove(tour);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Ticket Find(int? id)
        {
            Ticket t = new Ticket();
            t = _db.Tickets.Where(p => p.Id == id).FirstOrDefault();
            return t;
        }

        public void Insert(Ticket t)
        {
            _db.Tickets.Add(t);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Ticket t)
        {
            _db.Entry(t).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
