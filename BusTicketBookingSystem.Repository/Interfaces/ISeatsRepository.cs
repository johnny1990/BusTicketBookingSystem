using BusTicketBookingSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Interfaces
{
    public interface ISeatsRepository : IDisposable
    {
        IQueryable<Seat> All { get; }
        Seat Find(int? id);
        void Insert(Seat seat);
        void Update(Seat seat);
        void Delete(int id);
        void Save();
    }
}
