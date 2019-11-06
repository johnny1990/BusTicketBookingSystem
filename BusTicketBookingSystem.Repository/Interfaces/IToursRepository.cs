using BusTicketBookingSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Interfaces
{
    public interface IToursRepository : IDisposable
    {
        IQueryable<Tour> All { get; }
        Tour Find(int? id);
        void Insert(Tour tour);
        void Update(Tour tour);
        void Delete(int id);
        void Reserve(int id);
        void Save();
    }
}
