using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackStorkApp;
using BlackStorkApp.Models;
using BlackStorkApp.Controllers;
using BLL.Services;
using BLL.Interfaces;
using BLL.DTO;
using Moq;

namespace BlackStorkApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController controller;

        [TestInitialize]
        public void SetupContext()
        {
            controller = new HomeController();
        }

        [TestMethod]
        public void Index_RequestOfView_ViewIsNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Feedback_RequestOfView_ViewIsNotNull()
        {
            var result = controller.Feedback() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Feedback_RequestOfView_ReturnedViewFeedback()
        {
            var result = controller.Feedback() as ViewResult;
            Assert.AreEqual("Feedback", result.ViewName);
        }

        [TestMethod]
        public void SubscribeToNews_RequestOfView_ViewIsNotNull()
        {
            var mock = new Mock<IMainService<SubscribeDTO>>();
            var subscribe = new SubscribeModel();
            var controller = new HomeController(mock.Object);

            var result = controller.SubscribeToNews(subscribe) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SubscribeToNews_RequestOfView_ReturnedViewIndex()
        {
            var mock = new Mock<IMainService<SubscribeDTO>>();
            var subscribe = new SubscribeModel();
            var controller = new HomeController(mock.Object);

            var result = controller.SubscribeToNews(subscribe) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }



    }
}
