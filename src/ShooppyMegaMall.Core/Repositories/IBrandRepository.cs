using ShooppyMegaMall.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Core.Repositories
{
   public interface IBrandRepository
    {
        Task<List<Brands>> GetBrands(int orgid);
        Task<List<f_getproducts_By_OrgID>> GetCategoryBy_Org(int orgid);
        Task<List<SP_getproducts_By_NewArrivals>> _Getproducts_By_NewArrivals(int orgid);
        Task<List<sp_getcat_Result>> Sp_Getcat(int orgid);
        Task<List<F_getproducts_By_CatId>> Get_Product_By_Cat(int ID);
        Task<List<CategoryMaster>> CategoryMaster(int orgid);
        Task<List<f_getproducts_Recentlyviewed>> F_Getproducts_Recentlyviewed(string id, int orgid);
        Task<List<F_getproducts_By_BrandId>> GetProductsByBrand(int OrgId, int BrandId);
        Task News_Letter_Submit(int orgid, string email);
        Task<List<ProductBasic>>SearchProduct(string searchKey, int orgid);
        Task<ProductPrice> GetPrice(Guid productGuid);
        Task<f_order_master> GetMyOrders(int orderid);
        Task<List<f_order_master>> GetOrderedproductDetails(int orderid);
        Task<OrderShipping> GetOrderShipping(Guid? orderGUID);
        Task<UsersProfile> GetShippingDetail(string userName,int orgid);
        Task<List<ProductBasic>> GetProductDetail(string productName, string coverImage);
        Task CancleOrder(int orderid);
        Task<Users> GetUser(string email,int orgid);
        Task<OrderStatus> GetOrderStatus(int orderid,int orgid);
        Task<Organization> GetOrg(int? orgId);
        Task<Messages> SendMessageVendor(Messages messages);
        Task<List<Messages>> Get_Vendor_Message(string userName, int orgid);
        Task<List<Messages>> GetUnReadCount(int orgid, string username);
    }
}
