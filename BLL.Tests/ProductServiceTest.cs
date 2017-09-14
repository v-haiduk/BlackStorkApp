using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Services;
using BLL.Interfaces;
using BLL.DTO;
using DAL.Interfaces;
using DAL.Entities;
using Moq;

namespace BLL.Tests
{
    [TestClass]
    public class ProductServiceTest
    {
        private IMainService<ProductDTO> service;

        public void SetupContext()
        {
            service = new ProductService(null);
        }

        [TestMethod]
        public void GetAllElements_RequestOfCollection_CollectionIsNotNull()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Products.GetAllElements()).Returns(new List<Product>() );
            var service = new ProductService(mock.Object);

            var result = service.GetAllElements() as IEnumerable<ProductDTO>;

            Assert.IsNotNull(result);
        }

  
        [TestMethod]
        public void GetElement_InputExistingId_ProductReturned()
        {
            int? productId = 2;
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Products.GetElement(productId.Value)).Returns(new Product() );
            var service = new ProductService(mock.Object);

            var result = service.GetElement(productId.Value) as ProductDTO;

            Assert.IsNotNull(result);
        }


        //[TestMethod]
        //public void GetElement_InputNonExistingId_ProductReturned()
        //{
        //    int? productId = null;
        //    var mock = new Mock<IUnitOfWork>();
        //    mock.Setup(a => a.Products.GetElement(productId.Value)).Throws(new ValidationException("Извините, но ничего не найдено", ""));
        //    var service = new ProductService(mock.Object);

        //    var result = service.GetElement(productId);
        //}

        //[TestMethod]
        //public void CreateElement_InputCorrectData_SuccessfulSave()
        //{
        //    var mock = new Mock<IUnitOfWork>();
        //    var product = new ProductDTO {
        //                                Name ="TEST",
        //                                Description ="TEST TEST",
        //                                PathForMainPhoto = null,
        //                                PathForFolderWithPhotos = null };
        //    var service = new ProductService(mock.Object);

        //    service.CreateElement(product);

        //    mock.Verify(a => a.Products.Create( ) );
        //    mock.Verify(a => a.SaveChanges());
        //}


    }
}
