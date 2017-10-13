using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail;
using System.Web.Helpers;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BlackStorkApp.Models;
using BlackStorkApp.Interfaces;
using AutoMapper;
using BlackStorkApp.Controllers;


namespace BlackStorkApp.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        private readonly IFormsAuthenticationService formsAuthentication;


        public AccountController(IUserService service, IFormsAuthenticationService authentification)
        {
            userService = service;
            formsAuthentication = authentification;
        }

        /// <summary>
        /// The method returns the view of Login or Index, if the user unauthenticated, 
        /// he will redirect to the Login page. If user is authenticated, 
        /// he will redirect to the Index page
        /// </summary>
        /// <returns>The views of login or index</returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View("Login");
        }

        /// <summary>
        /// The method performs an authorization of user
        /// </summary>
        /// <param name="user">The user-data for authenticated</param>
        /// <returns>The views of login or index</returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserAccountModel user)
        {
            var login = user.Login;
            var passwordHash = user.HashOfPassword;
            var searchResults = userService.GetByLogin(login);

            if (searchResults != null)
            {
                if (searchResults.HashOfPassword == passwordHash)
                {
                    formsAuthentication.SetAuthCookie(user.Login, true);
                    return RedirectToAction("Index", "Admin");
                }
            }

            ModelState.AddModelError("", "Ошибка! Пожалуйста, проверьте ввееденные данные!");

            return View("Login", user);
        }

        /// <summary>
        /// The method close's the session
        /// </summary>
        [Authorize]
        public ActionResult LogOff(UserAccountModel user)
        {
            formsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        /// <summary>
        /// The method returns the page for reset of password
        /// </summary>
        /// <returns>The view of reset password</returns>
        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View("ResetPassword");
        }

        /// <summary>
        /// The method performs the operations for reset of password and 
        /// sends the message for creating the new password
        /// </summary>
        /// <param name="login">The login of user</param>
        /// <returns>The view of messageSent of noUser</returns>
        [HttpPost]
        public ActionResult ResetPassword(string login)
        {
            if (login == null)
            {
                return HttpNotFound();
            }

            var searchResults = userService.GetByLogin(login);
            if (searchResults != null)
            {
                CreateMessage(login);
            }
            else
            {
                return View("NoUser");
            }

            return View("MessageSent");
        }

        /// <summary>
        /// The method creates the message for changing password
        /// </summary>
        /// <param name="loginForSendMessage">The login of user, which get the message</param>
        private void CreateMessage(string loginForSendMessage)
        {
            string emailOfSender = "test.blackstork@gmail.com";

            var sender = new MailAddress(emailOfSender);
            var receiver = new MailAddress(loginForSendMessage);
            var message = new MailMessage(sender, receiver)
            {
                Subject = "Восстановление пароля на сайте Black Stork",
                Body = string.Format("Для восстановления пароля перейдите по данной ссылке: " +
                            "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
                Url.Action("PasswordRecovery", "Account", new { loginForPasswordRecovery = loginForSendMessage }, Request.Url.Scheme)),
                IsBodyHtml = true
            };

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(message);

        }

        /// <summary>
        /// The method returns the page for recovery of password
        /// </summary>
        /// <param name="loginForPasswordRecovery">The login of user</param>
        /// <returns>The view password recovery</returns>
        [HttpGet]
        public ActionResult PasswordRecovery(string loginForPasswordRecovery)
        {
            if (loginForPasswordRecovery == null)
            {
                return HttpNotFound();
            }

            var userDTOForEdit = userService.GetByLogin(loginForPasswordRecovery);
            if (userDTOForEdit == null)
            {
                return HttpNotFound();
            }

            Mapper.Initialize(configuration => configuration.CreateMap<UserAccountDTO, UserAccountModel>());
            var userForEdit = Mapper.Map<UserAccountDTO, UserAccountModel>(userDTOForEdit);

            return View("PasswordRecovery", userForEdit);
        }

        /// <summary>
        /// The method resets the old password and saves the new password
        /// </summary>
        /// <param name="user">The user-data, which contain the new password</param>
        /// <returns>The view login</returns>
        [HttpPost]
        public ActionResult PasswordRecovery(UserAccountModel user)
        {
            if (user == null)
            {
                return HttpNotFound();
            }

            Mapper.Initialize(configuraton => configuraton.CreateMap<UserAccountModel, UserAccountDTO>());
            var userForEdit = Mapper.Map<UserAccountModel, UserAccountDTO>(user);
            userService.UpdateElement(userForEdit);

            return RedirectToAction("Login");
        }


    }
}