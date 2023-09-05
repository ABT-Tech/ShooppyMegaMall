using System;
using System.Collections.Generic;
using System.Text;

namespace Shoppite.Application.Models
{
    public class F_getproducts_By_CatIdModel
    {
        public int OrgId { get; set; }
        public string BrandName { get; set; }
        public int brandid { get; set; }
        public string image { get; set; }
        public int ProductId { get; set; }
        public Nullable<System.Guid> ProductGUID { get; set; }
        public string ProductName { get; set; }
        public string URLPath { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Banner { get; set; }
        public string SKU { get; set; }
        public Nullable<System.DateTime> ProductStartDate { get; set; }
        public Nullable<System.DateTime> ProductEndDate { get; set; }
        public Nullable<bool> IsPublished { get; set; }
        public Nullable<System.DateTime> InsertDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ProfileId { get; set; }
        public Nullable<int> Category_Id { get; set; }
        public string category_name { get; set; }
        public string categoryurlpath { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> OldPrice { get; set; }
        public string maincaturlpath { get; set; }
        public Nullable<int> maincatid { get; set; }
        public string CurrencyName { get; set; }
    }
}
