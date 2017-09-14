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
    public class TopicServiceTest
    {
        private IMainService<TopicDTO> service;

        public void SetupContext()
        {
            service = new TopicService(null);
        }

        [TestMethod]
        public void GetAllElements_RequestOfCollection_CollectionIsNotNull()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Topics.GetAllElements()).Returns(new List<Topic>());
            var service = new TopicService(mock.Object);

            var result = service.GetAllElements() as IEnumerable<TopicDTO>;

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void GetElement_InputExistingId_TopicReturned()
        {
            int? TopicId = 2;
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Topics.GetElement(TopicId.Value)).Returns(new Topic());
            var service = new TopicService(mock.Object);

            var result = service.GetElement(TopicId.Value) as TopicDTO;

            Assert.IsNotNull(result);
        }
    }
}
