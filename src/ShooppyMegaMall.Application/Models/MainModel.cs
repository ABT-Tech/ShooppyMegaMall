using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShooppyMegaMall.Application.Models
{
   public class MainModel
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public int SpecId { get; set; }
        public Guid? guid { get; set; }
        public string ContactNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 15 char")]
        [DataType(DataType.Password)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be  between 8 to 15 characters and contain One UpperCase,One LowerCase and One number")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and Confirm Password should match")]
        [Required]
        public string CPassword { get; set; }
        public string Address { get; set; }
        public string OrderStatus { get; set; }
        public int WishlistId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public IFormFile ProfileImage { get; set; }
        public string CoverImage { get; set; }
        public string UserName { get; set; }
        public string Username { get; set; }
        public DateTime? InsertDate { get; set; }
        public string Ip { get; set; }
        public int? OrgId { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string searchKey { get; set; }
        public string category_name { get; set; }
        public string Banner { get; set; }
        public List<BrandsModel> BrandsModel { get; set; }
        public List<SP_getproducts_By_NewArrivalsModel> ProductNewArrivalModel { get; set; }
        public List<f_getproducts_By_OrgIDModel> f_Getproducts_By_OrgIDModel { get; set; }
        public List<sp_getcat_ResultModel> GetSp_Getcat_ResultModel { get; set; }
        public List<f_getproducts_By_CategoryIDModel> F_Getproducts_By_CategoryIDModels { get; set; }
        public List<CategoryMasterModel> CategoryMasterModel { get; set; }
        public CategoryMasterModel CategoryMaster { get; set; }
        public List<CategoryMasterModel> TopBanner { get; set; }
        public List<CategoryMasterModel> BannersByCategory { get; set; }
        public List<CategoryMasterModel> LeftBanner { get; set; }
        public List<CategoryMasterModel> CategoryBanner { get; set; }
        public List<CategoryMasterModel> MiddelBanner { get; set; }
        public IEnumerable<MainCategoryModel> ProductsDetails { get; set; }
        public List<SpecificationSetupModel> Specification { get; set; }
        public List<CategoryMasterModel> CategoryProduct { get; set; }
        public List<CategoryMasterModel> Categories { get; set; }
        public List<CategoryMasterModel> SubCategories { get; set; }
        public List<CategoryMasterModel> BottomBanner { get; set; }
        public List<AttributeSetupModel> Attributes { get; set; }
        public List<f_getproducts_By_CatID_SpecificationNameModel> Product_specification { get; set; }
        public List<Customer_WishlistModel> Wishlists { get; set; }
        public List<f_order_masterModel> MyOrders { get; set; }
        public List<f_order_masterDetailsModel> MyOrderDetails { get; set; }
        public List<F_Pending_Orders_Model> Orders { get; set; }
        public List<f_Get_MyAccount_Data_Model> Myaccount { get; set; }
        public List<sp_getcat_ResultModel> AllCategories { get; set; }
        public List<F_getproducts_By_BrandIdModel> ProductdByBrand { get; set; }
        public ProductRecentlyViewedModel ProductRecentlyViewedModel { get; set; }
        public List<f_getproducts_RecentlyviewedModel> f_Getproducts_RecentlyviewedModel { get; set; }
        public List<F_getproducts_By_CatIdModel> f_getproducts_By_CatIdModel { get; set; }
        public ProductBasicModel ProductBasicModel { get; set; }
    }
}
