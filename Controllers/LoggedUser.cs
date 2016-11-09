using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poppel.Models;
using System.Collections.ObjectModel;

namespace Poppel.Controllers
{
    /**
    *The LoggedUser method tracks a users active session. Including their login and cart information
    *@param Product
    *@return View
    */
    public class LoggedUser : User
    {
        public static User loggedUser {get; set;}

        public static Collection<OrderItem> ShoppingCart = new Collection<OrderItem>();
    }
}
