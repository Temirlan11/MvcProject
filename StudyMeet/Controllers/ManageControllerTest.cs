using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace StudyMeet.Controllers
{
   [TestClass]
    public class ManageControllerTest
    {
        private ManageController controller;
        private ViewResult result;
       [TestMethod]
        public void IndexViewResultNotNull()
        {
            controller = new ManageController();
            result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            controller = new ManageController();
            result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexStringInViewbag()
        {
            controller = new ManageController();
            result = controller.Index() as ViewResult;
            Assert.AreEqual("Hello world!", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            controller = new ManageController();
            result = controller.About() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}