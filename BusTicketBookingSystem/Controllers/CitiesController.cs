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
using Microsoft.Ajax.Utilities;

namespace BusTicketBookingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CitiesController : Controller
    {
        private readonly ICityRepository repository;

        public CitiesController(ICityRepository objIrepository)
        {
            repository = objIrepository;
        }

        // GET: Cities
        public ActionResult Index()
        {
            return View(repository.All.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = repository.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult InsertCity(City city)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(city);
                repository.Save();
            }

            return Json(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = repository.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }

            ViewBag.Id = id;

            return View(city);
        }

        [HttpPost]
        public JsonResult UpdateCity(City city)
        {
            if (ModelState.IsValid)
            {
                repository.Update(city);
                repository.Save();
                return Json("Ok");
            }
            else
                return Json("Not ok");
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = repository.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }

            ViewBag.Id = id;
            return View(city);
        }

        [HttpPost]
        public JsonResult DeleteCity(int id)
        {
            repository.Delete(id);
            repository.Save();

            return Json("");
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
