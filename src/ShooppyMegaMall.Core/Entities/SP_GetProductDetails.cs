using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Core.Entities
{
   public partial class SP_GetProductDetails
    {
        public Guid ProductGUID { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public string Brand { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SpecificationIds { get; set; }
        public string SpecificationNames { get; set; }
        //public string SpecificationImage { get; set; }
        public string Attribute { get; set; }
        public string ProductList { get; set; }
        public int OrgId { get; set; } 
    }
}
