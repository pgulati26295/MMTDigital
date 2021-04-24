using MMT.CustomerOrder.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMT.CustomerOrder.Core.Entities
{
   public class Orders : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OrderId { get; set; }

        [StringLength(10)]
        public string CustomerId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DeliveryExpected { get; set; }
        public bool ContainsGift { get; set; }

        [StringLength(30)]
        public string ShippingMode { get; set; }

        [StringLength(30)]
        public string OrderSource { get; set; }

        public virtual List<OrderItems> OrderItems { get; set; }


    }
}
