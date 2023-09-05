using Shoppite.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Application.Models
{
    public class CategoryMasterModel
    {
        public int ProductId { get; set; }
        public int AdId { get; set; }
        public int AttributeName { get; set; }
        public string SpecificationName { get; set; }
        public int AttributeId { get; set; }
        public int SpecificationId { get; set; }
        public int AdsPlacementId { get; set; }
        public string category_name { get; set; }
        public string CategoryName { get; set; }
        public int Category_Id { get; set; }
        public int CategoryId { get; set; }
        public string Logo1 { get; set; }
        public string Favicon { get; set; }
        public string Urlpath { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Banner { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsShowHomePage { get; set; }
        public bool? IsIncludeMenu { get; set; }
        public string SeoPageName { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string UserName { get; set; }
        public int? DisplayOrder { get; set; }
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; }
        public int? OrgId { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
        public string CoverImage { get; set; }
        public List<CategoryMasterModel> TopBanner { get; set; }
        public List<CategoryMasterModel> BottomBanner { get; set; }
    }
    public class MainCategoryModel
    {
        public string maincaturlpath { get; set; }
        
        public Nullable<int> maincatid { get; set; }
        public string Banner { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsShowHomePage { get; set; }
        public bool? IsIncludeMenu { get; set; }

        public List<CategoryProductModel> SubcategoryDetails { get; set; }
    }
    public class CategoryProductModel
    {
        public int? CategoryId { get; set; }
        public string Banner { get; set; }
        public string CategoryName { get; set; }
        public int ParentCategoryId { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsShowHomePage { get; set; }
        public bool? IsIncludeMenu { get; set; }
        public List<ProductBaseModel> ProductsDetails { get; set; }
    }
    public class ProductBaseModel
    {
        public int? ProductId { get; set; }
        public Guid? ProductGuid { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string CoverImage { get; set; }
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; }
    }
    public class SpecificationSetupModel
    {
        public int SpecificationId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public string SpecificationName { get; set; }
        public string SpecificiatoinDescription { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UserName { get; set; }
        public int? ProfileId { get; set; }
        public decimal? Price { get; set; }
        public int? OrgId { get; set; }
        public List<AttributeSetupModel> attributes { get; set; }
    }
    public class AttributeSetupModel
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }
        public string UserName { get; set; }
        public int? OrgId { get; set; }
        public List<SpecificationSetupModel> specifications { get; set; }
    }

}
