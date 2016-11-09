using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Poppel.Models;

namespace Poppel.Controllers
{
    public class RegisterController : Controller
    {
        private PoppelDBEntities db = new PoppelDBEntities();
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(User model)
        {
            User customer = new User();
            customer.Account = model.Account;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.EmailAddress = model.EmailAddress;
            customer.Password = model.Password;
            customer.Status = "C";

            db.Users.Add(customer);
            db.SaveChanges();

            return RedirectToAction("Login","Login");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}