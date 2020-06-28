using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models.ViewModels
{
    public class OrderDetailsCart
    {
        public List<ShoppingCart> listCart { get; set; }
        //we won't use all properties of OrderHeader
        public OrderHeader OrderHeader { get; set; }
    }
}
