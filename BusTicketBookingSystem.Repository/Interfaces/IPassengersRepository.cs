using BusTicketBookingSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Interfaces
{
    public interface IPassengersRepository : IDisposable
    {
        IQueryable<Passenger> All { get; }
        Passenger Find(int? id);
        void Insert(Passenger pas);
        void Update(Passenger pas);
        void Delete(int id);
        void Save();
    }
}
