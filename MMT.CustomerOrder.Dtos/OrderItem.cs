using System;
using System.Collections.Generic;
using System.Text;

namespace MMT.CustomerOrder.Dtos
{
   public class OrderItem
    {
        public string Product { get; set; }
        public int? Quantity { get; set; }

        public decimal? PriceEach { get; set; }
    }
}
