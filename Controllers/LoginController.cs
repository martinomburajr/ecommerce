using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Poppel.Models.ViewModel;
using Poppel.Models.BusinessModel;

namespace Poppel.Controllers
{
    public class LoginController : Controller
    {
        UserService userService = new UserService();
        String Status = "";
        // GET: Login

        /**
            *The Login Action allows for the LoginViewModel to be sent to the view to collect the users login details
            *@param
            *@return View
             */
        public ActionResult Login()
        {
            try { Status = LoggedUser.loggedUser.Status; } catch (Exception) { }
            
            LoginViewModel viewModel = new LoginViewModel();
            ViewBag.Status = "";
            if(this.Status == null || ViewBag.Status == "")
            {
                this.Status = "C";
            }else
            {
                ViewBag.Status = Status;
            }
            
            return View(viewModel);
        }
        /**
        *The LogOut method logs the user out of the session
        *@param 
        *@return View
        */
        public ActionResult LogOut()
        {
            LoggedUser.loggedUser = null;
            LoggedUser.ShoppingCart.Clear();
            return RedirectToAction("Index", "Home");
        }

        /**
        *The ValidateLogin checks against the service which checks agains the database to authenticate a user
        *@param LoginViewModel, form
        *@return View
        */
        public ActionResult ValidateLogin(LoginViewModel login, FormCollection form)
        {
            String status = form["UserStatus"].ToString();
            bool valid = userService.validateLogin(login.EmailAddress, login.Password, status);
            if (valid)
            {
                LoggedUser.loggedUser = userService.getUserByEmail(login.EmailAddress);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Wrong details";
                return RedirectToAction("Login", "Login", new {msg = "Wrong Details" });
            }
        }

    }
}