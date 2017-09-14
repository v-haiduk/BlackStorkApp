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
    public class UserServiceTest
    {
        private IMainService<UserAccountDTO> service;

        public void SetupContext()
        {
            service = new UserService(null);
        }

        [TestMethod]
        public void GetAllElements_RequestOfCollection_CollectionIsNotNull()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.UsersAccounts.GetAllElements()).Returns(new List<UserAccount>());
            var service = new UserService(mock.Object);

            var result = service.GetAllElements() as IEnumerable<UserAccountDTO>;

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void GetElement_InputExistingId_UserAccountReturned()
        {
            int? UserAccountId = 2;
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.UsersAccounts.GetElement(UserAccountId.Value)).Returns(new UserAccount());
            var service = new UserService(mock.Object);

            var result = service.GetElement(UserAccountId.Value) as UserAccountDTO;

            Assert.IsNotNull(result);
        }
    }
}
