using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel.Models.BusinessModel
{
    public class ShoppingCartService : ServiceManager
    {
       
        public decimal CalculateTotal()
        {
            decimal total = 0.0M;
            foreach (OrderItem orderItem in Poppel.Controllers.LoggedUser.ShoppingCart)
            {
                total = total + orderItem.Product.Cost;
            }
            return total;
        }
    }
}
