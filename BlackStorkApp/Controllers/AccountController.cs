using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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

        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserAccountModel user)
        {
            var login = user.Login;
            var passwordHash = user.HashOfPassword;
            var searchResults = userService.GetByLogin(login);

            if (searchResults != null)
            {
                if (passwordHash == searchResults.HashOfPassword)
                {
                    FormsAuthentication.SetAuthCookie(user.Login, true);
                    return RedirectToAction("Index", "Admin");
                }
            }

            ModelState.AddModelError("", "Введенный пароль неверен!"); //change!

            return View("Index", user);
        }

        /// <summary>
        /// The method close's the session
        /// </summary>
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}