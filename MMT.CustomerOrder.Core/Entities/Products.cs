using MMT.CustomerOrder.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMT.CustomerOrder.Core.Entities
{
   public class Products : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [Column(TypeName ="decimal(9,2)")]
        public decimal PackHeight { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal PackWidth { get; set; }

        [Column(TypeName = "decimal(8,3)")]
        public decimal PackWeight { get; set; }

        [StringLength(20)]
        public string Colour { get; set; }

        [StringLength(20)]
        public string Size { get; set; }

        public virtual List<OrderItems> OrderItems { get; set; }
    }
}
