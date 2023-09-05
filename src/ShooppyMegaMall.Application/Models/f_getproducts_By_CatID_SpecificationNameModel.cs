using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Application.Models
{
    public class f_getproducts_By_CatID_SpecificationNameModel
    {
        public string image { get; set; }
        public int ProductId { get; set; }
        public int SpecificationId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public Nullable<System.Guid> ProductGUID { get; set; }
        public string SpecificationName { get; set; }
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
        //public int StatusId { get; set; }
        public string deals { get; set; }
        //public string badgestatus { get; set; }
        //public string CurrencyName { get; set; }
       // public string shopname { get; set; }
        //public string ShopURLPath { get; set; }
        //public string logo { get; set; }
      /*  public string brands { get; set; }*/
        public string BrandName { get; set; }
        public string brandsurlpath { get; set; }
        public int brandid { get; set; }
        public string UserName { get; set; }
        public string status { get; set; }
        public Nullable<int> totalpick { get; set; }
        public Boolean IsDefault { get; set; }

    }
}
