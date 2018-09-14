using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestApp;
using UnitTestApp.Controllers;
using Moq;
using UnitTestApp.Models;

namespace UnitTestApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexViewModelNotNull()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>());
            HomeController controller = new HomeController(mock.Object);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreatePostAction_ModelError()
        {
            string expected = "Create";
            var mock = new Mock<IRepository>();
            Computer comp = new Computer();
            HomeController controller = new HomeController(mock.Object);
            controller.ModelState.AddModelError("Name", "Название модели не установлено");

            ViewResult result = controller.Create(comp) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }

        [TestMethod]
        public void CreatePostAction_RedirectToIndexView()
        {
            string expected = "Index";
            var mock = new Mock<IRepository>();
            Computer comp = new Computer();
            HomeController controller = new HomeController(mock.Object);

            RedirectToRouteResult result = controller.Create(comp) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        public void CreatePostAction_SaveModel()
        {
            var mock = new Mock<IRepository>();
            Computer comp = new Computer();
            HomeController controller = new HomeController(mock.Object);

            RedirectToRouteResult result = controller.Create(comp) as RedirectToRouteResult;

            mock.Verify(a => a.Create(comp));
            mock.Verify(a => a.Save());
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
