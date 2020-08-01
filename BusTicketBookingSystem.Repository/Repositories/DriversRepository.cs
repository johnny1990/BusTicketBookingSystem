using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingSystem.Repository.Repositories
{
    public class DriversRepository : IDriversRepository
    {
        TicketBookingModelEntities _db;

        public DriversRepository(TicketBookingModelEntities db)
        {
            this._db = db;
        }

        public IQueryable<Driver> All
        {
            get { return _db.Drivers; }
        }

        public void Delete(int id)
        {
            var driver = _db.Drivers.Find(id);
            _db.Drivers.Remove(driver);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Driver Find(int? id)
        {
            Driver Driver = new Driver();
            Driver = _db.Drivers.Where(p => p.DriverId == id).FirstOrDefault();
            return Driver;
        }

        public void Insert(Driver driver)
        {
            _db.Drivers.Add(driver);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Driver driver)
        {
            _db.Entry(driver).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
