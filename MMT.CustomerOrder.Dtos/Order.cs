using System;
using System.Collections.Generic;
using System.Text;

namespace MMT.CustomerOrder.Dtos
{
   public class Order
    {
        public int orderNumber { get; set; }
        public string orderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime DeliveryExpected { get; set; }
    }
}
