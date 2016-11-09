using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Poppel.Models;
using Poppel.Models.BusinessModel;
using Poppel.Models.ViewModel;

namespace Poppel.Controllers
{
    
    public class ShoppingCartController : Controller
    {
        //private PoppelDBEntities db = new PoppelDBEntities();
        ProductService ps = new ProductService(); 

        // GET: ShoppingCart
        public ActionResult Index()
        {
            ViewBag.ShoppingCart = LoggedUser.ShoppingCart;
            return View();
        }

        /**
        *The AddToCart method takes a product from the list then uses the AddToCart service to validate that
        *stock exists and then adds to cart
        *@param Product
        *@return View
        */

        public ActionResult AddToCart(Product product)
        {
            if(LoggedUser.loggedUser == null)
            {
                return RedirectToAction("Index", "Products");
            }
            else
            {
                int quantity = (int)product.Quantity;
                int productId = product.Id;

                bool valid = ps.validateAddToCart(productId, quantity);
                if (valid)
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.ProductId = productId;
                    orderItem.Product = ps.getProductById(productId);
                    orderItem.Quantity = quantity;
                    LoggedUser.ShoppingCart.Add(orderItem);
                }

                return RedirectToAction("Index", "Products");
            }
        }
    }
}