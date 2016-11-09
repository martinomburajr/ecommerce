using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel.Models.BusinessModel
{
    class PoppelStoreService : ServiceManager
    {

        public Boolean validateAddToCart(int productId, int quantity)
        {
            PoppelStore ps = getPoppelStoreByProductId(productId);
            if (ps.Stock - quantity != 0)
            {
                return true;
            }
            return false;
        }
        public PoppelStore getPoppelStoreByProductId(int productId)
        {
            return db.PoppelStores.FirstOrDefault(i => i.ProductId == productId);
        }
        public Boolean deductProducts(OrderItem orderItem)
        {
            bool done = false;
            try
            {
                PoppelStore item = db.PoppelStores.FirstOrDefault(i => i.ProductId == orderItem.ProductId);
                item.Stock = item.Stock - orderItem.Quantity;
                db.SaveChanges();
                done = true;
            }catch(Exception)
            {

            }
          
            return done;
        }
    }
}
