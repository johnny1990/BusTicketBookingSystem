using BusTicketBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Contracts
{
    public interface ICityRepository : IDisposable
    {
        IQueryable<City> All { get; }
        City Find(int? id);
        void Insert(City city);
        void Update(City city);
        void Delete(int id);
        void Save();
    }
}
