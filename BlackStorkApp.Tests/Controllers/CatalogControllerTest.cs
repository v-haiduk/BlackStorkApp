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
    public class CatalogControllerTest
    {
        [TestMethod]
        public void Index_RequestOfView_ViewIsNotNull()
        {
            var mock = new Mock<IMainService<ProductDTO>>();
            mock.Setup(a => a.GetAllElements()).Returns(new List<ProductDTO>());
            var controller = new CatalogController(mock.Object);

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_RequestOfView_ReturnedViewIndex()
        {
            var mock = new Mock<IMainService<ProductDTO>>();
            mock.Setup(a => a.GetAllElements()).Returns(new List<ProductDTO>());
            var controller = new CatalogController(mock.Object);

            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Product_RequestOfView_ViewIsNotNull()
        {
            int? productId = 1;
            var mock = new Mock<IMainService<ProductDTO>>();
            mock.Setup(a => a.GetElement(productId.Value)).Returns(new ProductDTO());
            var controller = new CatalogController(mock.Object);

            var result = controller.Product(productId.Value) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Product_RequestOfView_ReturnedViewProduct()
        {
            int? productId = 1;
            var mock = new Mock<IMainService<ProductDTO>>();
            mock.Setup(a => a.GetElement(productId.Value)).Returns(new ProductDTO());
            var controller = new CatalogController(mock.Object);

            var result = controller.Product(productId.Value) as ViewResult;
            Assert.AreEqual("Product", result.ViewName);
        }

    }
}
