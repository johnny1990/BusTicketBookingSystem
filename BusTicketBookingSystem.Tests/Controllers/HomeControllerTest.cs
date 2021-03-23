using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusTicketBookingSystem;
using BusTicketBookingSystem.Controllers;
using BusTicketBookingSystem.Models;

namespace BusTicketBookingSystem.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Feedback()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Feedback() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Sent()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Sent() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();
            Contact contact = new Contact();
            // Act
            ViewResult result = controller.Contact(contact) as ViewResult;

            // Assert
            Assert.IsNull(result);
        }
    }
}
