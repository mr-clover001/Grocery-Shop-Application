using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data_Access_Layer.Repository.Entities
{
    public class MyOrders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(250)]
        public string Description { get; set; }

        public int? Quantity { get; set; }
        [StringLength(250)]
        public string ImageFileName { get; set; }
        public double? Price { get; set; }
        public int? Discount { get; set; }
        [StringLength(250)]
        public string Specification { get; set; }
        public int? AvaiableQuantity { get; set; }

        [StringLength(250)]
        public string Category { get; set; }
    }
}
