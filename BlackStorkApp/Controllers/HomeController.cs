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

namespace BlackStorkApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(FeedbackModel feedback)
        {
            string email = "violetta.haiduk@gmail.com";
            string password = "********"; //CHANGE PASSWORD

            var loginInfo = new NetworkCredential(email, password);
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);

            var message = CreateMessage(feedback, email);
            
            //check this region!!!
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(message);

            return View();
        }

        private MailMessage CreateMessage(FeedbackModel feedback, string email)
        {
            var message = new MailMessage();
            message.From = new MailAddress(email);
            message.To.Add(new MailAddress(feedback.Email));
            message.Subject = feedback.UserName;
            message.Body = feedback.MessageText;
            message.IsBodyHtml = true;

            return message;
        }
    }
}