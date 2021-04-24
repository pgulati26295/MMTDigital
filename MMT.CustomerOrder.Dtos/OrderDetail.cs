using System;
using System.Collections.Generic;
using System.Text;

namespace MMT.CustomerOrder.Dtos
{
  public  class OrderDetail
    {
        public Customer Customer { get; set; }
        public Order Order { get; set; }

        
    }
}
