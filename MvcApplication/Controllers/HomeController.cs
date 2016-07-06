using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    //בכל פעם שיוצאת בקשה לשרת 
    //הקונטרולר מופעל והפונקציה שקראנו לו מתבצעת
    //בסוף נגיד לו איזה view להציג
    //ומה להזריק לתוך הדף.
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        //פונקציה אשר מחזירה/מציגה את דף הבית
        public ViewResult Index()
        {
            Home modelHome = new Home();
            return View("HomeView",modelHome);
        }        


    }
}
