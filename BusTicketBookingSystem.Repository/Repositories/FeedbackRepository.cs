using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        TicketBookingModelEntities _db;

        public FeedbackRepository(TicketBookingModelEntities db)
        {
            this._db = db;
        }
        public IQueryable<Feedback> All
        {
            get { return _db.Feedbacks; }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Insert(Feedback f)
        {
            _db.Feedbacks.Add(f);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
