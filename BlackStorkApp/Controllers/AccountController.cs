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

        [Authorize]
        public ActionResult Index()
        {
            return View("Index");
        }

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
                if (passwordHash == searchResults.HashOfPassword)
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
    }
}