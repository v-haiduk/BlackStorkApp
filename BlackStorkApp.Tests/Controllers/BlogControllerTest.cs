using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackStorkApp.Controllers;
using BLL.Interfaces;
using BLL.DTO;
using Moq;

namespace BlackStorkApp.Tests.Controllers
{
    [TestClass]
    public class BlogControllerTest
    {

        [TestMethod]
        public void Index_RequestOfView_ViewIsNotNull()
        {
            var mock = new Mock<IMainService<TopicDTO>>();
            mock.Setup(a => a.GetAllElements()).Returns(new List<TopicDTO>() );
            var controller = new BlogController(mock.Object);

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_RequestOfView_ReturnedViewIndex()
        {
            var mock = new Mock<IMainService<TopicDTO>>();
            mock.Setup(a => a.GetAllElements()).Returns(new List<TopicDTO>());
            var controller = new BlogController(mock.Object);

            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void GetDescriptionOfNews_RequestOfView_ViewIsNotNull()
        {
            int? topicId = 1;
            var mock = new Mock<IMainService<TopicDTO>>();
            mock.Setup(a => a.GetElement(topicId.Value)).Returns(new TopicDTO());
            var controller = new BlogController(mock.Object);

            var result = controller.GetDescriptionOfNews(topicId.Value) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDescriptionOfNews_RequestOfView_ReturnedViewGetDescription()
        {
            int? topicId = 1;
            var mock = new Mock<IMainService<TopicDTO>>();
            mock.Setup(a => a.GetElement(topicId.Value)).Returns(new TopicDTO());
            var controller = new BlogController(mock.Object);

            var result = controller.GetDescriptionOfNews(topicId.Value) as ViewResult;
            Assert.AreEqual("News", result.ViewName);
        }
    }
}
