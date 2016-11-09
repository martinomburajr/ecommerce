using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel.Models.ViewModel
{
    public class ShoppingCartViewModel
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Cost { get; set; }
        public string Image { get; set; }

        public List<Product> Products { get; set; }

        public Collection<OrderItem> OrderItems { get; set; }

    }
}
