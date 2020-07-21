using BusTicketBookingSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Interfaces
{
    public interface IFeedbackRepository : IDisposable
    {
        IQueryable<Feedback> All { get; }
        void Insert(Feedback f);
        void Save();
    }
}
