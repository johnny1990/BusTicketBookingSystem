
using BusTicketBookingSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Interfaces
{
    public interface IReservationsRepository : IDisposable
    {
        IQueryable<Reservation> All { get; }
        Reservation Find(int? id);
        void Insert(Reservation res);
        void Update(Reservation res);
        void Delete(int id);
        void Save();
    }
}
