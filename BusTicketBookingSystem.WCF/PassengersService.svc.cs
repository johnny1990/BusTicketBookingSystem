using BusTicketBookingSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BusTicketBookingSystem.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PassengersService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PassengersService.svc or PassengersService.svc.cs at the Solution Explorer and start debugging.
    public class PassengersService : IPassengersService
    {
        public int AddPassenger(string Name, bool Blocked)
        {
            TicketBookingModelEntities db = new TicketBookingModelEntities();
            Passenger p = new Passenger();
            p.Name = Name;
            p.Blocked = Blocked;
            db.Passengers.Add(p);
            int Retval = db.SaveChanges();
            return Retval;
        }

        public int DeletePassengerById(int Id)
        {
            TicketBookingModelEntities db = new TicketBookingModelEntities();
            Passenger p = new Passenger();
            p.Id = Id;
            db.Entry(p).State = EntityState.Deleted;
            int Retval = db.SaveChanges();
            return Retval;
        }

        public List<Passenger> GetAllPassengers()
        {
            List<Passenger> Plst = new List<Passenger>();
            TicketBookingModelEntities db = new TicketBookingModelEntities();
            var lstD = from k in db.Passengers select k;
            foreach (var item in lstD)
            {
                Passenger p = new Passenger();
                p.Id = item.Id;
                p.Name = item.Name;
                p.Blocked = item.Blocked;
               
                Plst.Add(p);
            }
            return Plst;
        }

        public Passenger GetPassengerById(int Id)
        {
            TicketBookingModelEntities db = new TicketBookingModelEntities();
            var lstD = from k in db.Passengers where k.Id == Id select k;
            Passenger p = new Passenger();
            foreach (var item in lstD)
            {
                p.Id = item.Id;
                p.Name = item.Name;
                p.Blocked = item.Blocked;
            }

            return p;
        }

        public int UpdatePassenger(int Id, string Name, bool Blocked)
        {
            TicketBookingModelEntities db = new TicketBookingModelEntities();
            Passenger p = new Passenger();
            p.Id = Id;
            p.Name = Name;
            p.Blocked = Blocked;
            db.Entry(p).State = EntityState.Modified;

            int Retval = db.SaveChanges();
            return Retval;
        }
    }
}
