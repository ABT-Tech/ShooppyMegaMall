using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Core.Entities
{
   public class f_getproducts_By_CategoryID_Result
    {
        public string image { get; set; }
        public int ProductId { get; set; }
        public Nullable<System.Guid> ProductGUID { get; set; }
        public string ProductName { get; set; }   
        public Nullable<int> Category_Id { get; set; }
        public string category_name { get; set; }
        public string categoryurlpath { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> OldPrice { get; set; }
        public string maincaturlpath { get; set; }
        public Nullable<int> maincatid { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsShowHomePage { get; set; }
        public bool? IsIncludeMenu { get; set; }


    }
}
