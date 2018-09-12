using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestApp.Controllers;
using System.Web.Mvc;

namespace UnitTestApp.Tests.Controllers
{
    [TestClass]
    public class StoreControllerTest
    {
        private StoreController controller;
        private ViewResult result;

        [TestInitialize]
        public void SetupContext()
        {
            controller = new StoreController();
            result = controller.Index() as ViewResult;
        }

        [TestMethod]
        public void IndexViewResultNull()
        {
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexStringInViewbag()
        {
            Assert.AreEqual("Hello world!", result.ViewBag.Message);
        }
    }
}
