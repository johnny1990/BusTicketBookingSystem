using BusTicketBookingSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Interfaces
{
    public interface IDriversRepository : IDisposable
    {
        IQueryable<Driver> All { get; }
        Driver Find(int? id);
        void Insert(Driver driver);
        void Update(Driver driver);
        void Delete(int id);
        void Save();
    }
}
