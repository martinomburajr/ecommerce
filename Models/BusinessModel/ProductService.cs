using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poppel.Models;


namespace Poppel.Models.BusinessModel
{
    public class ProductService : ServiceManager
    {
        public Product getProductById(int id)
        {
            Product product = db.Products.FirstOrDefault(i => i.Id == id);
            return product;
        }

        public Boolean validateAddToCart(int productId, int quantity)
        {
            Product ps = getProductById(productId);
            if (ps.Quantity - quantity >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
