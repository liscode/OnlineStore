using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class FooterMenuController : Controller
    {
        //
        // GET: /FooterMenu/

        public ActionResult Index()
        {
            return View();
        }

        //פונקציה שמטרתה להציג לנו את ה-about
        //שנמצא בfootermenu
        public ActionResult About()
        {
            About modelAbout= new About();
            return View("AboutView", modelAbout);
        }

    }
}
