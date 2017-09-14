using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BlackStorkApp.Models;
using AutoMapper;

namespace BlackStorkApp.Controllers
{
    public class HomeController : Controller
    {
        private IMainService<SubscribeDTO> subscribeService;

        public HomeController(IMainService<SubscribeDTO> sService)
        {
            subscribeService = sService;
        }

        public HomeController() { }


        /// <summary>
        /// The method returns a view of Main-page
        /// </summary>
        /// <returns>The view of main-page</returns>
        public ActionResult Index()
        {
            return View("Index");
        }

        /// <summary>
        /// The method returns a view of AboutUs-page, which contain description of company
        /// </summary>
        /// <returns>The view of aboutUs-page</returns>
        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }

        /// <summary>
        /// The method returns a view of feedback
        /// </summary>
        /// <returns>The view with forms for feedback</returns>
        [HttpGet]
        public ActionResult Feedback()
        {
            return View("Feedback");
        }

        /// <summary>
        /// The method organizes a feedback. Gmail use as a smtp-server.
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns>The view with forms of feedback</returns>
        [HttpPost]
        public ActionResult Feedback(FeedbackModel feedback)
        {
            string email = "test.blackstork@gmail.com";
            string password = "02072017tb";

            var loginInfo = new NetworkCredential(email, password);
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);

            var message = CreateMessage(feedback, email);
            
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(message);

            return PartialView("MessageSent");
            //return RedirectToAction("Index");
        }

        /// <summary>
        /// the method creates the message for send across smtp-client
        /// </summary>
        /// <param name="feedback">The model with data entered by the user</param>
        /// <param name="emailOfRecipient">The email of recipient (administrator of site)</param>
        /// <returns>The message to send</returns>
        private MailMessage CreateMessage(FeedbackModel feedback, string emailOfRecipient)
        {
            var sender = new MailAddress(feedback.Email);
            var receiver = new MailAddress(emailOfRecipient);
            var message = new MailMessage(sender, receiver);
            message.Subject = "Сообщение с сайта black-stork.net от  " + feedback.Email;
            message.Body = feedback.MessageText;
            message.IsBodyHtml = true;
            
            return message;
        }

        /// <summary>
        /// The method adds the new e-mail in list of newsletter
        /// </summary>
        /// <param name="item">The new email</param>
        /// <returns>The view of main-page</returns>
        [HttpPost]
        public ActionResult SubscribeToNews(SubscribeModel item)
        {
            Mapper.Initialize(configuration => configuration.CreateMap<SubscribeModel, SubscribeDTO>());
            var newEmail =  Mapper.Map<SubscribeModel, SubscribeDTO>(item);
            subscribeService.CreateElement(newEmail);

            return View("Index");
        }
    }
}