using BusTicketBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Contracts
{
    public interface IBusRepository : IDisposable
    {
        IQueryable<Bus> All { get; }
        Bus Find(int? id);
        void Insert(Bus bus);
        void Update(Bus bus);
        void Delete(int id);
        void Save();
    }
}
