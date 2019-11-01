
using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTicketBookingSystem.Repository.Repository
{
    public class CityRepository : ICityRepository
    {
        TicketBookingModelEntities _db;

        public CityRepository(TicketBookingModelEntities db)
        {
            this._db = db;
        }

        public IQueryable<City> All
        {
            get { return _db.Cities; }
        }
      
        public void Delete(int id)
        {
            var bus = _db.Cities.Find(id);
            _db.Cities.Remove(bus);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public City Find(int? id)
        {
            City objCity = new City();
            objCity = _db.Cities.Where(p => p.CityId == id).FirstOrDefault();
            return objCity;
        }

        public void Insert(City city)
        {
            _db.Cities.Add(city);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(City city)
        {
            _db.Entry(city).State = System.Data.Entity.EntityState.Modified;

        }
    }
}