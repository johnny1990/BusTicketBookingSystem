using BusTicketBookingSystem.Entities.Models;
using BusTicketBookingSystem.Models;
using BusTicketBookingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BusTicketBookingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IFeedbackRepository repository;
        public HomeController(IFeedbackRepository objIrepository)
        {
            repository = objIrepository;
        }

        public HomeController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Feedback([Bind(Include = "Id,FromPassenger,FromEmail,FeedBack1")] Feedback model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("mail", "Online Apple Shopping Store Feedback");
                    var receiverEmail = new MailAddress(model.FromEmail, model.FromPassenger);
                    var password = "password";
                    var subject = "Feedback notification";
                    var body = model.Feedback1;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var message = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                        repository.Insert(model);
                        repository.Save();
                    }
                    return RedirectToAction("Sent");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
            }
            return RedirectToAction("Sent");
        }

        [HttpGet]
        public ActionResult Sent()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FeedbackList()
        {
            return View(repository.All.ToList());
        }

        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]//to modify
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                //db.Contact.Add(contact);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index", contact);
        }
    }
}