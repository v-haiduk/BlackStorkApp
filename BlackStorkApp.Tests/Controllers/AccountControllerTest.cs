using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackStorkApp.Controllers;
using BlackStorkApp.Models;
using BlackStorkApp.Interfaces;
using BLL.Services;
using BLL.Interfaces;
using BLL.DTO;
using Moq;



namespace BlackStorkApp.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        private AccountController controller;

        [TestInitialize]
        public void SetupContext()
        {
            var userService = DependencyResolver.Current.GetService<UserService>();
            controller = new AccountController(userService, null);
        }


        [TestMethod]
        public void Login_InputCorrectUserData_UserAuthentication()
        {
            var mockUser = new Mock<IUserService>();
            var mockAuth = new Mock<IFormsAuthenticationService>();
            var user = new UserAccountModel { Login = "test@test.com", HashOfPassword = "123" };
            mockUser.Setup(a => a.GetByLogin(user.Login)).Returns(new UserAccountDTO {Login=user.Login, HashOfPassword=user.HashOfPassword } );
            var controller = new AccountController(mockUser.Object, mockAuth.Object);

            var result = controller.Login(user) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Login_InputIncorrectUserData_RepeatedInput()
        {
            var mock = new Mock<IUserService>();
            var user = new UserAccountModel { Login = "test11@test.com", HashOfPassword = "3214" };
            mock.Setup(a => a.GetByLogin(user.Login)).Returns((UserAccountDTO)null );
            var controller = new AccountController(mock.Object, null);

            var result = controller.Login(user) as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
        }

        [TestMethod]
        public void LogOff_RedirectToLogin()
        {
            var user = new UserAccountModel { Login = "test@test.com", HashOfPassword = "123" };
            var mock = new Mock<IFormsAuthenticationService>();
            var controller = new AccountController(null, mock.Object);

            var result = controller.LogOff(user) as RedirectToRouteResult;
            Assert.AreEqual("Login", result.RouteValues["action"]);
        }

        #region Tests for reset of password

        [TestMethod]
        public void ResetPassword_RequestOfView_ViewIsNotNull()
        {
            var result = controller.ResetPassword() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ResetPassword_RequestOfView_ReturnedViewRessetPassword()
        {
            var result = controller.ResetPassword() as ViewResult;
            Assert.AreEqual("ResetPassword", result.ViewName);
        }

        /*The tests doesn't work, because resetPassword include the method 'createMessage'*/
        [TestMethod]
        public void ResetPassword_InputExistingLogin_ReturnedViewMessageSent()
        {
            var login = "v-haiduk@hotmail.com";
            var mock = new Mock<IUserService>();
            mock.Setup(a => a.GetByLogin(login)).Returns(new UserAccountDTO() );
            var controller = new AccountController(mock.Object, null);

            var result = controller.ResetPassword(login) as ViewResult;
            Assert.AreEqual("MessageSent", result.ViewName);
        }

        [TestMethod]
        public void ResetPassword_InputNonExistingLogin_ReturnedViewNoUser()
        {
            var login = "smith@test.com";
            var mock = new Mock<IUserService>();
            mock.Setup(a => a.GetByLogin(login)).Returns((UserAccountDTO)null);
            var controller = new AccountController(mock.Object, null);

            var result = controller.ResetPassword(login) as ViewResult;
            Assert.AreEqual("NoUser", result.ViewName);
        }
        #endregion


        #region Tests for recovery of password

        [TestMethod]
        public void PasswordRecovery_InputNullForLogin_ReturnedPageError()
        {
            string login = null;
            var result = controller.PasswordRecovery(login);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void PasswordRecovery_InputCorrectLogin_ReturnedViewPasswordRecovery()
        {
            string login = "v-haiduk@hotmail.com";
            var mock = new Mock<IUserService>();
            mock.Setup(a => a.GetByLogin(login)).Returns(new UserAccountDTO());

            var controller = new AccountController(mock.Object, null);
            var result = controller.PasswordRecovery(login) as ViewResult;
            Assert.AreEqual("PasswordRecovery", result.ViewName);
        }

        [TestMethod]
        public void PasswordRecovery_InputCorrectNewModel_ReturnedViewLogin()
        {
            var mock = new Mock<IUserService>();
            var user = new UserAccountModel();
            var controller = new AccountController(mock.Object, null);

            var result = controller.PasswordRecovery(user) as RedirectToRouteResult;
            Assert.AreEqual("Login", result.RouteValues["action"]);
        }

        [TestMethod]
        public void PasswordRecovery_InputInCorrectNewModel_ReturnedPageError()
        {
            var mock = new Mock<IUserService>();
            UserAccountModel user = null;
            var controller = new AccountController(mock.Object, null);

            var result = controller.PasswordRecovery(user);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        #endregion


    }
}
