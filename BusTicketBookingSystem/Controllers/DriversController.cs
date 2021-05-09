using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Repository.Interfaces;

namespace BusTicketBookingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DriversController : Controller
    {
        private readonly IDriversRepository repository;

        public DriversController(IDriversRepository objIrepository)
        {
            repository = objIrepository;
        }

        DriversServiceReference.DriversServiceClient srv = new DriversServiceReference.DriversServiceClient();

        // GET: Drivers
        public ActionResult Index()
        {
            List<Driver> lstRecord = new List<Driver>();

            var lst = srv.GetAllDrivers();

            foreach (var item in lst)
            {
                Driver usr = new Driver();
                usr.DriverId = item.DriverId;
                usr.Name = item.Name;
                usr.SerialNumber = item.SerialNumber;
                usr.DriverLicence = item.DriverLicence;
                usr.PhoneNumber = item.PhoneNumber;
                usr.EmailAddress = item.EmailAddress;
                usr.IsAvailable = item.IsAvailable;
                lstRecord.Add(usr);
            }

            return View(lstRecord);
        }

        // GET: Drivers/Details/5
        public ActionResult Details(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = srv.GetDriverById(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
            
        }

        // GET: Drivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverId,Name,SerialNumber,DriverLicence,PhoneNumber,EmailAddress,ProfilePicture,IsAvailable")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                Driver usr = new Driver();
                usr.DriverId = driver.DriverId;
                usr.Name = driver.Name;
                usr.SerialNumber = driver.SerialNumber;
                usr.DriverLicence = driver.DriverLicence;
                usr.PhoneNumber = driver.PhoneNumber;
                usr.EmailAddress = driver.EmailAddress;
                usr.IsAvailable = driver.IsAvailable;
                srv.AddDriver(usr.Name, usr.SerialNumber, usr.DriverLicence, usr.PhoneNumber, usr.EmailAddress, usr.IsAvailable);
                return RedirectToAction("Index");
            }

            return View(driver);
            
        }

        // GET: Drivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = repository.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverId,Name,SerialNumber,DriverLicence,PhoneNumber,EmailAddress,ProfilePicture,IsAvailable")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                repository.Update(driver);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = repository.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {          
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
