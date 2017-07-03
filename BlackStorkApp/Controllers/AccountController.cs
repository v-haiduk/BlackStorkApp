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
using AutoMapper;
using BlackStorkApp.Controllers;


namespace BlackStorkApp.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;

        public AccountController(IUserService service)
        {
            userService = service;
        }

        //[Authorize]
        //public ActionResult Index()
        //{
        //    return View("Index");
        //}

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

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
                    FormsAuthentication.SetAuthCookie(user.Login, true);
                    return RedirectToAction("Index", "Admin" );
                }
            }

            ModelState.AddModelError("", "Ошибка! Пожалуйста, проверьте ввееденные данные!");

            return View(user);
        }

        /// <summary>
        /// The method close's the session
        /// </summary>
        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

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

        private void CreateMessage(string loginForSendMessage)
        {
            string emailOfSender = "test.blackstork@gmail.com";
            string password = "02072017tb"; 

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

            SetupOfSend(emailOfSender, password, message);
        }

        private void SetupOfSend(string emailOfSender, string password, MailMessage message)
        {
            var loginInfo = new NetworkCredential(emailOfSender, password);
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = loginInfo
            };

            smtpClient.Send(message);
        }


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
            var userForEdit =  Mapper.Map<UserAccountDTO, UserAccountModel>(userDTOForEdit);

            return View(userForEdit);
        }

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