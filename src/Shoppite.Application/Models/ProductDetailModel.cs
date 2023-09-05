using System;
using System.Collections.Generic;
using System.Text;

namespace Shoppite.Application.Models
{
    public class ProductDetailModel
    {
        public int SpecId { get; set; }
        public ProductBasicModel ProductBasicModel { get; set; }
        public List<Customer_WishlistModel> Wishlists { get; set; }
        public List<ProductImagesModel> ProductImagesModel { get; set; }
        public ProductPriceModel ProductPriceModel { get; set; }
        public MainModel MainModel { get; set; }
        public BrandsModel BrandsModel { get; set; }
        public ProductBrand ProductBrandsModel { get; set; }
        public ProductCategoryModel ProductCategoryModel { get; set; }
        public List<f_getproducts_By_CategoryIDModel> f_Getproducts_By_CategoryIDModels { get; set; }
        public ProductRecentlyViewedModel ProductRecentlyViewedModel { get; set; }
        public List<f_getproducts_RecentlyviewedModel> f_Getproducts_RecentlyviewedModel { get; set; }
        public List<f_getproduct_specification_By_GuidModel> f_Getproduct_Specification_By_GuidModel { get; set; }
        public List<AttributesSetupModel> AttributesSetupModel { get; set; }
        public OrderBasicModel OrderBasicModel { get; set; }
        public OrderMasterModel OrderMasterModel { get; set; }
        public List<ProductVariantModel> productVariantModel  { get; set; }
        public List<SP_GetProductSpecificationsModel> Sp_GetProductSpecificationsModels { get; set; }

    }
}
