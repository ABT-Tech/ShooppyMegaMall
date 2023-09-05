using Shoppite.Application.Models;
using Shoppite.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shoppite.Application.Mapper
{
    // The best implementation of AutoMapper for class libraries -> https://www.abhith.net/blog/using-automapper-in-a-net-core-class-library/
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ShoppiteDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class ShoppiteDtoMapper : AutoMapper.Profile
    {
        public ShoppiteDtoMapper()
        {
            CreateMap<Brands, BrandsModel>().ReverseMap();
            CreateMap<List<Brands>, BrandsModel>().ReverseMap();
            CreateMap<List<f_getproducts_By_NewArrivals>, f_getproducts_By_NewArrivalsModel>().ReverseMap();
            CreateMap<f_getproducts_By_NewArrivals, f_getproducts_By_NewArrivalsModel>().ReverseMap();
            CreateMap<IQueryable<f_getproducts_By_NewArrivals>, List<f_getproducts_By_NewArrivalsModel>>().ReverseMap();
            CreateMap<f_getproducts_By_OrgID, f_getproducts_By_OrgIDModel>().ReverseMap();
            CreateMap<sp_getcat_Result, sp_getcat_ResultModel>().ReverseMap();
            CreateMap<f_getproducts_By_CategoryID, f_getproducts_By_CategoryIDModel>().ReverseMap();
            CreateMap<CategoryMaster, CategoryMasterModel>().ReverseMap();
            CreateMap<ProductBasic,ProductBasicModel>().ReverseMap();
            CreateMap<ProductBasic,ProductDetailModel>().ReverseMap();
            CreateMap<ProductImages,ProductImagesModel>().ReverseMap();
            CreateMap<ProductPrice,ProductPriceModel>().ReverseMap();
            CreateMap<Brands,BrandsModel>().ReverseMap();
            CreateMap<ProductBrand,ProductBrand>().ReverseMap();
            CreateMap<ProductCategory,ProductCategoryModel>().ReverseMap();
            CreateMap<ProductRecentlyViewed, ProductRecentlyViewedModel>().ReverseMap();
            CreateMap<ProductRecentlyViewed, ProductDetailModel>().ReverseMap();
            CreateMap<f_getproducts_Recentlyviewed,f_getproducts_RecentlyviewedModel>().ReverseMap();
            CreateMap<OrderBasic,OrderBasicModel>().ReverseMap();
            CreateMap<f_getproduct_specification_By_Guid,f_getproduct_specification_By_GuidModel>().ReverseMap();
            CreateMap<AttributesSetup,AttributesSetupModel>().ReverseMap();
            CreateMap<f_getproduct_CartDetails_By_Orgid,f_getproduct_CartDetails_By_OrgidModel>().ReverseMap();
            CreateMap<OrderShipping,OrderShippingModel>().ReverseMap();
            CreateMap<Logo,LogoModel>().ReverseMap();
            CreateMap<Users,UsersModal>().ReverseMap();
            CreateMap<UsersProfileModal,UsersModal>().ReverseMap();
            CreateMap<OrderMaster,OrderMasterModel>().ReverseMap();
            CreateMap<UsersProfile,UsersProfileModal>().ReverseMap();
            CreateMap<F_getproducts_By_CatId,F_getproducts_By_CatIdModel>().ReverseMap();
            CreateMap<UsersProfile,MainModel>().ReverseMap();
            CreateMap<f_order_master, f_order_masterModel>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusModel>().ReverseMap();
            CreateMap<Messages, MessagesModel>().ReverseMap();
            CreateMap<ProductVariant, ProductVariantModel>().ReverseMap();
            CreateMap<SP_GetProductDetails, SP_GetProductDetailsModel>().ReverseMap();
            CreateMap<SP_GetProductSpecifications, SP_GetProductSpecificationsModel>().ReverseMap();

            CreateMap<CategoryMasterModel, CategoryMaster>().ReverseMap();
            CreateMap<CategoryMasterModel, AdsDetail>().ReverseMap();
            CreateMap<CategoryMasterModel, ProductBasicModel>().ReverseMap();
            CreateMap<CategoryMasterModel, f_All_getcat_Result>().ReverseMap();
            CreateMap<CategoryMasterModel, f_getproducts_By_CategoryID_Result>().ReverseMap();
            CreateMap<CategoryMasterModel, Logo>().ReverseMap();
            CreateMap<CategoryMasterModel, f_getproducts_By_CategoryID>().ReverseMap();
            CreateMap<SpecificationSetup, SpecificationSetupModel>().ReverseMap();
            CreateMap<f_getproducts_By_CatID_SpecificationNameModel, f_getproducts_By_CategoryID>().ReverseMap();
            CreateMap<f_getproducts_By_CatID_SpecificationName, f_getproducts_By_CatID_SpecificationNameModel>().ReverseMap();
            CreateMap<SP_UserWishList, Customer_WishlistModel>().ReverseMap();
            CreateMap<MainModel, CustomerWishlist>().ReverseMap();
            CreateMap<F_Orders_All, F_Orders_All_Model>().ReverseMap();
            CreateMap<F_Pending_Orders, F_Pending_Orders_Model>().ReverseMap();
            CreateMap<f_Get_MyAccount_Data_Model, f_Get_MyAccount_Data>().ReverseMap();
            CreateMap<f_Get_MyAccount_Data, f_Get_MyAccount_Data_Model>().ReverseMap();
            CreateMap<MainModel, UsersProfileModal>().ReverseMap();
            CreateMap<f_Get_MyAccount_Data_Model, UsersProfileModal>().ReverseMap();
            CreateMap<MainModel, Users>().ReverseMap();
            CreateMap<F_getproducts_By_CatId, f_getproducts_By_CatID_SpecificationNameModel>().ReverseMap();
            CreateMap<F_getproducts_By_BrandId, F_getproducts_By_BrandIdModel>().ReverseMap();
            CreateMap<f_order_masterDetails, f_order_masterDetailsModel>().ReverseMap();
            CreateMap<f_getproduct_varient_By_Guid, f_getproduct_varient_By_GuidModel>().ReverseMap();
            CreateMap<ProductSpecificationModel, ProductSpecification>().ReverseMap();
            CreateMap<ProductSpecificationModel, ProductSpecification>().ReverseMap();
            CreateMap<VendorContactDetails, (int,string,string)>().ReverseMap();

        }
    }
}
