using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Poppel.Models;
using Poppel.Models.BusinessModel;
using Poppel.Models.ViewModel;

namespace Poppel.Controllers
{
    public class TransactionsController : Controller
    {
        private PoppelDBEntities db = new PoppelDBEntities();
        UserService cs = new UserService();
        ProductService ps = new ProductService();
        ShoppingCartService sc = new ShoppingCartService();
        PoppelStoreService pss = new PoppelStoreService();
        bool paymentValidated = false;

        // GET: Transactions
        public ActionResult Index()
        {
            //ViewBag.ShoppingCart = ShoppingCartService.ShoppingCart;
            ViewBag.Total = sc.CalculateTotal();
                       
            if(LoggedUser.loggedUser != null)
            {
                ViewBag.Status = LoggedUser.loggedUser.Status.Trim();
            }
            else
            {
                ViewBag.Status = "";
            }

            ViewBag.ShoppingCart = LoggedUser.ShoppingCart;
            return View(new LoggedUser());
        }

        public ActionResult ValidatePurchase(FormCollection form)
        {
            String emailAddress = form["emailaddress"].ToString();
            decimal total = sc.CalculateTotal();
            bool creditStatus = cs.CreditStatusOK(emailAddress, total);
            paymentValidated = creditStatus;
            return View();
        }

        public ActionResult Purchase(FormCollection form)
        {
            //Check if payment has been validated
            //Deduct payment from customer account
            //Remove inventory from stock
            // Update Inventory
            //Clear Cart
            //Show message of purchase

            String email = form["email"].ToString();

            if(paymentValidated)
            {
                decimal total = sc.CalculateTotal();
                cs.DeductCredit(email, total);
                
                foreach(OrderItem orderItem in Poppel.Controllers.LoggedUser.ShoppingCart)
                {
                    //pss.deductProduct(product.Id, product.)
                }

            } else
            {
                String Message = "You have insufficient funds";
            }

            return View();
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.ShoppingCart = LoggedUser.ShoppingCart;
            ViewBag.Id = (int)id;
            if (LoggedUser.ShoppingCart[(int)id] == null)
            {
                return View(LoggedUser.ShoppingCart[(int)id]);
            }
            else
            {
                return View(LoggedUser.ShoppingCart[(int)id]);
            }
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.OrderItemId = new SelectList(db.OrderItems, "Id", "Id");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,OrderItemId,Amount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FirstName", transaction.UserId);
            ViewBag.OrderItemId = new SelectList(db.OrderItems, "Id", "Id", transaction.OrderItemId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FirstName", transaction.UserId);
            ViewBag.OrderItemId = new SelectList(db.OrderItems, "Id", "Id", transaction.OrderItemId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,OrderItemId,Amount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FirstName", transaction.UserId);
            ViewBag.OrderItemId = new SelectList(db.OrderItems, "Id", "Id", transaction.OrderItemId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ShoppingCart = LoggedUser.ShoppingCart;
            ViewBag.Id = (int)id;
            if (LoggedUser.ShoppingCart[(int)id] == null)
            {
                return View(LoggedUser.ShoppingCart[(int)id]);
            }
            else
            {
                return View(LoggedUser.ShoppingCart[(int)id]);
            }
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoggedUser.ShoppingCart.RemoveAt(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
