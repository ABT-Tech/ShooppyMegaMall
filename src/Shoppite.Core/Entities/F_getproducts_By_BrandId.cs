using System;
using System.Collections.Generic;
using System.Text;

namespace Shoppite.Core.Entities
{
    public class F_getproducts_By_BrandId
    {
        public string Image { get; set; }
        public int OrgId { get; set; }
        public int ProductId { get; set; }
        public Guid? ProductGuid { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> OldPrice { get; set; }
        public string ProductName { get; set; }
        public string Urlpath { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        //public int? Qty { get; set; }
        public DateTime? ProductStartDate { get; set; }
        public DateTime? ProductEndDate { get; set; }
        public bool? IsPublished { get; set; }
        public int BrandId { get; set; }
        //public int? CategoryId { get; set; }
        public string BrandName { get; set; }
        //public string BrandDescription { get; set; }
        public string BrandImage { get; set; }
       // public string BrandUrlpath { get; set; }
    }
}
