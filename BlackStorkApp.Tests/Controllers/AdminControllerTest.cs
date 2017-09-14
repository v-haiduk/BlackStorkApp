using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackStorkApp.Controllers;
using BlackStorkApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using Moq;

namespace BlackStorkApp.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        private AdminController controller;

        [TestInitialize]
        public void SetupContext()
        {
            controller = new AdminController(null, null, null);
        }


        #region Tests for Products

        [TestMethod]
        public void CreateOfProduct_RequestOfView_ViewIsNotNull()
        {
            ViewResult result = controller.CreateOfProduct() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateOfProduct_RequestOfView_ReturnedViewCreateOfProduct()
        {
            ViewResult result = controller.CreateOfProduct() as ViewResult;
            Assert.AreEqual("CreateOfProduct", result.ViewName);
        }

        [TestMethod]
        public void CreateOfProduct_InpurCorrectData_RedirectToGetAllProducts()
        {
            var mock = new Mock<IMainService<ProductDTO>>();
            var product = new ProductModel();
            var controller = new AdminController(mock.Object, null, null);

            var result = controller.CreateOfProduct(product) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("GetAllProducts", result.RouteValues["action"]);
        }

        [TestMethod]
        public void GetAllProduct_RequestOfView_ViewIsNotNull()
        {
            var mock = new Mock<IMainService<ProductDTO>>();
            mock.Setup(a => a.GetAllElements()).Returns(new List<ProductDTO>());
            var controller = new AdminController(mock.Object, null, null);

            ViewResult result = controller.GetAllProducts() as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void EditOfProduct_RequestOfExistingProduct_ReturnedViewEditOfProduct()
        {
            int productId = 2;
            var mock = new Mock<IMainService<ProductDTO>>();
            mock.Setup(a => a.GetElement(productId)).Returns(new ProductDTO() );
            var controller = new AdminController(mock.Object, null, null);

            var result = controller.EditOfProduct(productId) as ViewResult;
            Assert.AreEqual("EditOfProduct", result.ViewName);
        }

        [TestMethod]
        public void EditOfProduct_RequestOfNonExistingProduct_ReturnedPageError()
        {
            int productId = 2;
            var mock = new Mock<IMainService<ProductDTO>>();
            mock.Setup(a => a.GetElement(productId)).Returns((ProductDTO)null);
            var controller = new AdminController(mock.Object, null, null);

            var result = controller.EditOfProduct(productId);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void GetDescriptionOfProduct_RequestOfView_ViewIsNotNull()
        {
            int productId = 2;
            var mock = new Mock<IMainService<ProductDTO>>();
            mock.Setup(a => a.GetElement(productId)).Returns((ProductDTO)null);
            var controller = new AdminController(mock.Object, null, null);

            var result = controller.GetDescriptionOfProduct(productId) as PartialViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDescriptionOfProduct_RequestOfView_ReturndViewGetDescription()
        {
            int productId = 2;
            var mock = new Mock<IMainService<ProductDTO>>();
            mock.Setup(a => a.GetElement(productId)).Returns((ProductDTO)null);
            var controller = new AdminController(mock.Object, null, null);

            var result = controller.GetDescriptionOfProduct(productId) as PartialViewResult;
            Assert.AreEqual("DescriptionOfProduct", result.ViewName);
        }

        [TestMethod]
        public void GetAllProducts_RequestOfView_ReturnedViewGetAllProducts()
        {
            var mock = new Mock<IMainService<ProductDTO>>();
            mock.Setup(a => a.GetAllElements()).Returns(new List<ProductDTO>());
            var controller = new AdminController(mock.Object, null, null);

            var result = controller.GetAllProducts() as ViewResult;
            Assert.AreEqual("AllProducts", result.ViewName);
        }

        #endregion



        #region Tests for Topics

        [TestMethod]
        public void CreateOfTopic_RequestOfView_ViewIsNotNull()
        {
            var result = controller.CreateOfTopic() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateOfTopic_RequestOfView_ReturnedViewCreateOfTopic()
        {
            var result = controller.CreateOfTopic() as ViewResult;
            Assert.AreEqual("CreateOfTopic", result.ViewName);
        }

        [TestMethod]
        public void CreateOfTopic_InputCorrectData_RedirectToGetAllTopics()
        {
            var mock = new Mock<IMainService<TopicDTO>>();
            var topic = new TopicModel();
            var controller = new AdminController(null, mock.Object, null);

            var result = controller.CreateOfTopic(topic) as RedirectToRouteResult;
            Assert.AreEqual("GetAllTopics", result.RouteValues["action"]);
        }
        
        [TestMethod]
        public void GetAllTopics_RequestOfView_ViewIsNotNull()
        {
            var mock = new Mock<IMainService<TopicDTO>>();
            mock.Setup(a => a.GetAllElements()).Returns(new List<TopicDTO>());
            var controller = new AdminController(null, mock.Object, null);

            var result = controller.GetAllTopics() as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void GetAllTopics_RequestOfView_ReturnedViewGetAllTopics()
        {
            var mock = new Mock<IMainService<TopicDTO>>();
            mock.Setup(a => a.GetAllElements()).Returns(new List<TopicDTO>());
            var controller = new AdminController(null, mock.Object, null);

            var result = controller.GetAllTopics() as ViewResult;
            Assert.AreEqual("AllTopics", result.ViewName);
        }

        [TestMethod]
        public void GetDescriptuionOfTopic_RequestOfView_ViewIsNotNull()
        {
            int topicId = 2;
            var mock = new Mock<IMainService<TopicDTO>>();
            mock.Setup(a => a.GetElement(topicId)).Returns(new TopicDTO());
            var controller = new AdminController(null, mock.Object, null);

            var result = controller.GetDescriptionOfTopic(topicId) as PartialViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDescriptuionOfTopic_RequestOfView_ReturnedViewGetDescription()
        {
            int topicId = 2;
            var mock = new Mock<IMainService<TopicDTO>>();
            mock.Setup(a => a.GetElement(topicId)).Returns(new TopicDTO());
            var controller = new AdminController(null, mock.Object, null);

            var result = controller.GetDescriptionOfTopic(topicId) as PartialViewResult;
            Assert.AreEqual("DescriptionOfTopic", result.ViewName);
        }


        [TestMethod]
        public void EditOfTopic_RequestOfExistingTopic_ReturnedViewEditOfTopic()
        {
            int topicId = 2;
            var mock = new Mock<IMainService<TopicDTO>>();
            mock.Setup(a => a.GetElement(topicId)).Returns(new TopicDTO() );
            var controller = new AdminController(null, mock.Object, null);

            var result = controller.EditOfTopic(topicId) as ViewResult;
            Assert.AreEqual("EditOfTopic", result.ViewName);
        }

        [TestMethod]
        public void EditOfTopic_RequestOfNonExistingTopic_ReturnedPageError()
        {
            int topicId = 243424129;
            var mock = new Mock<IMainService<TopicDTO>>();
            mock.Setup(a => a.GetElement(topicId)).Returns((TopicDTO)null);
            var controller = new AdminController(null, mock.Object, null);

            var result = controller.EditOfTopic(topicId);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        #endregion


        #region Tests for Subscribe

        [TestMethod]
        public void NewsLetter_RequestOfView_ViewIsNotNull()
        {
            var mock = new Mock<IMainService<SubscribeDTO>>();
            mock.Setup(a => a.GetAllElements()).Returns(new List<SubscribeDTO>());
            var controller = new AdminController(null, null, mock.Object);

            var result = controller.NewsLetter() as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void NewsLetter__RequestOfView_ReturnedViewNewsLetter()
        {
            var mock = new Mock<IMainService<SubscribeDTO>>();
            mock.Setup(a => a.GetAllElements()).Returns(new List<SubscribeDTO>());
            var controller = new AdminController(null, null, mock.Object);

            var result = controller.NewsLetter() as ViewResult;
            Assert.AreEqual("NewsLetter", result.ViewName);
        }

        [TestMethod]
        public void NewsLetter_InputCorrectData_RedirectToNewsletter()
        {
            var mock = new Mock<IMainService<SubscribeDTO>>();
            var subscribe = new SubscribeModel();
            var controller = new AdminController(null, null, mock.Object);

            var result = controller.NewsLetter(subscribe) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("NewsLetter", result.RouteValues["action"]);
        }

        #endregion

    }
}
