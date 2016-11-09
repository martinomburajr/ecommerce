using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel.Models.BusinessModel
{
    class OrderItemService : ServiceManager
    {
        public OrderItem findOrderItemById(int id)
        {
            return db.OrderItems.FirstOrDefault(i => i.Id == id);
        }
    }
}
