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
    public class SubscribeServiceTest
    {
        private IMainService<SubscribeDTO> service;

        public void SetupContext()
        {
            service = new SubscribeService(null);
        }

        [TestMethod]
        public void GetAllElements_RequestOfCollection_CollectionIsNotNull()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Subscribs.GetAllElements()).Returns(new List<Subscribe>());
            var service = new SubscribeService(mock.Object);

            var result = service.GetAllElements() as IEnumerable<SubscribeDTO>;

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void GetElement_InputExistingId_SubscribeReturned()
        {
            int? SubscribeId = 2;
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Subscribs.GetElement(SubscribeId.Value)).Returns(new Subscribe());
            var service = new SubscribeService(mock.Object);

            var result = service.GetElement(SubscribeId.Value) as SubscribeDTO;

            Assert.IsNotNull(result);
        }
    }
}
