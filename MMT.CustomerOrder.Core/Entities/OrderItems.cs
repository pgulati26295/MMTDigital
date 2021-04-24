using MMT.CustomerOrder.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMT.CustomerOrder.Core.Entities
{
  public  class OrderItems :IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }
        public int? OrderId { get; set; }
        public  Orders? Order { get; set; }
        public int? ProductId { get; set; }
        public  Products? Product { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public bool? Returnable{ get; set; }





    }
}
