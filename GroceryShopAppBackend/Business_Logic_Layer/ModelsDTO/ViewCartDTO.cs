using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.ModelsDTO
{
   public class ViewCartDTO
    {


        public int Id { get; set; }

        public string ProductName { get; set; }
    
        public string Description { get; set; }
        public int? Quantity { get; set; }
   
        public string ImageFileName { get; set; }
        public double? Price { get; set; }
        public int? Discount { get; set; }

        public string Specification { get; set; }

        public int? AvaiableQuantity { get; set; }
        
        public string Category { get; set; }
    }
}
