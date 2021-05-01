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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DriversService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DriversService.svc or DriversService.svc.cs at the Solution Explorer and start debugging.
    public class DriversService : IDriversService
    {
        public int AddDriver(string Name, string SerialNumber, string DriverLicence, string PhoneNumber, string EmailAddress, bool IsAvailable)
        {
            TicketBookingModelEntities db = new TicketBookingModelEntities();
            Driver drv = new Driver();
            drv.Name = Name;
            drv.SerialNumber = SerialNumber;
            drv.DriverLicence = DriverLicence;
            drv.PhoneNumber = PhoneNumber;
            drv.EmailAddress = EmailAddress;
            drv.IsAvailable = IsAvailable;
            db.Drivers.Add(drv);
            int Retval = db.SaveChanges();
            return Retval;
        }

        public int DeleteDriverById(int DriverId)
        {
            TicketBookingModelEntities db = new TicketBookingModelEntities();
            Driver drv = new Driver();
            drv.DriverId = DriverId;
            db.Entry(drv).State = EntityState.Deleted;
            int Retval = db.SaveChanges();
            return Retval;
        }

        public List<Driver> GetAllDrivers()
        {
            List<Driver> drvlst = new List<Driver>();
            TicketBookingModelEntities db = new TicketBookingModelEntities();
            var lstD = from k in db.Drivers select k;
            foreach (var item in lstD)
            {
                Driver drv = new Driver();
                drv.DriverId = item.DriverId;
                drv.Name = item.Name;
                drv.SerialNumber = item.SerialNumber;
                drv.DriverLicence = item.DriverLicence;
                drv.PhoneNumber = item.PhoneNumber;
                drv.EmailAddress = item.EmailAddress;
                drv.IsAvailable = item.IsAvailable;
                drvlst.Add(drv);
            }
                return drvlst;
        }

        public Driver GetDriverById(int DriverId)
        {
            TicketBookingModelEntities db = new TicketBookingModelEntities();
            var lstD= from k in db.Drivers where k.DriverId == DriverId select k;
            Driver drv = new Driver();
            foreach (var item in lstD)
            {
                drv.DriverId = item.DriverId;
                drv.Name = item.Name;
                drv.SerialNumber = item.SerialNumber;
                drv.DriverLicence = item.DriverLicence;
                drv.PhoneNumber = item.PhoneNumber;
                drv.EmailAddress = item.EmailAddress;
                drv.IsAvailable = item.IsAvailable;
            }

            return drv;
        }

        public int UpdateDriver(int DriverId, string Name, string SerialNumber, string DriverLicence, string PhoneNumber, string EmailAddress, bool IsAvailable)
        {
            TicketBookingModelEntities db = new TicketBookingModelEntities();
            Driver drv = new Driver();
            drv.DriverId = DriverId;
            drv.Name = Name;
            drv.SerialNumber = SerialNumber;
            drv.DriverLicence = DriverLicence;
            drv.PhoneNumber = PhoneNumber;
            drv.EmailAddress = EmailAddress;
            drv.IsAvailable = IsAvailable;
            db.Entry(drv).State = EntityState.Modified;

            int Retval = db.SaveChanges();
            return Retval;
        }
    }
}
