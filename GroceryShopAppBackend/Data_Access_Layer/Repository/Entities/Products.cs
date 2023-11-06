using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GroceryShopApp.Repository.Entities
{
    public partial class Products
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
