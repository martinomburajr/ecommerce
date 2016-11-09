using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Poppel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Welcome = "";
            try
            {
                ViewBag.Welcome = "Welcome " + LoggedUser.loggedUser.FirstName.Trim();
            }
            catch (Exception)
            {
                ViewBag.Welcome = "";
            }

            if(LoggedUser.loggedUser == null)
            {
                return View(LoggedUser.loggedUser);
            }
            else
            {
                return View(LoggedUser.loggedUser);
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}