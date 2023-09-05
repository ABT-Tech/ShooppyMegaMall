using Shoppite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shoppite.Core.Repositories
{
   public interface IProductDetailRepsitory
   {
        Task<ProductBasic> productBasic(Guid id);
        Task<List<ProductImages>> ProductImages(Guid id);
        Task<ProductPrice> productPrices(Guid id);
        Task<Brands> Get_Brand_Name(Guid guid, int id);
        Task<ProductCategory> Get_Product_Cat(Guid guid);
        Task<List<f_getproducts_By_CategoryID>> F_Getproducts_By_CategoryID(int id);
        Task<List<f_getproducts_Recentlyviewed>> F_Getproducts_Recentlyviewed(string id, int orgid);
        Task<ProductRecentlyViewed> GetIP(int orgid);
        Task AddIp(ProductRecentlyViewed productRecentlyViewed);
        Task<IEnumerable<f_getproduct_specification_By_Guid>> specificationSetups(Guid SpecGuid);
        Task<IEnumerable<AttributesSetup>> ProductAttribute(int OrgId);
        Task AddToCart(OrderBasic productDetailModel);
        Task UpdateAddToCart(OrderBasic productDetailModel);
        Task AddOrderMaster(OrderMaster orderMaster);
        Task<OrderBasic> check(OrderBasic productDetailModel);
        Task<OrderBasic> updateCart();
        Task<List<ProductVariant>> GetProductVarient(int orgid, Guid id, string username);
        Task<List<SP_GetProductDetails>>GetProductVarient(Guid guid, int orgid,int SpecId);
        Task<List<SP_GetProductSpecifications>> SP_GetProductSpecifications(Guid id, int orgid);
        Task<ProductSpecification> get_Product_SpecId(Guid? productGuid, int? orgId, int specId);
        Task<OrderVariation> Add_Order_Varient(OrderVariation orderVariation);
        Task<OrderVariation> Get_Order_Varient(OrderVariation orderVariation);
    }
}
