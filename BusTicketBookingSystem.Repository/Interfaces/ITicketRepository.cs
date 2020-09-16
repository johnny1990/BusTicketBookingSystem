using BusTicketBookingSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Interfaces
{
    public interface ITicketRepository : IDisposable
    {
        IQueryable<Ticket> All { get; }
        Ticket Find(int? id);
        void Insert(Ticket t);
        void Update(Ticket t);
        void Delete(int id);
        void Save();
    }
}
