using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlackStorkApp.Controllers
{
    public class ExceptionController : Controller
    {
        // GET: Exception
        public ActionResult Index()
        {
            return View("errorGeneral");
        }

        public ActionResult General(Exception exception)
        {
            return View("errorGeneral", exception);  //ДОБАВИТЬ
        }

        public ActionResult Http403()
        {
            Response.StatusCode = 403;
            return View("error403");
        }

        public ActionResult Http404()
        {
            Response.StatusCode = 404;
            return View("error404");
        }
    }

}