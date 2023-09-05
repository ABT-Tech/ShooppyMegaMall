using Shoppite.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppite.UI.Interfaces
{
   public interface IBrandPageServices
    {
        Task<MainModel> GetBrands(int orgId);
        Task<MainModel> GetCategoryBy_Org(int orgId);
        Task<MainModel> GetnewProduct(int orgid);
        Task<MainModel> Sp_Getcat(int orgid);
        Task<MainModel> Get_Product_By_Cat(int ID);
        Task<MainModel> CategoryMater(int orgid);
        Task<List<F_getproducts_By_BrandIdModel>> GetProductsByBrand(int OrgId,int BrandId);
        Task News_Letter_Submit(int orgid, string email);
        Task<List<ProductBasicModel>> SearchProduct(string searchKey,int orgid);
        Task<OrderModel> GetOrderDetails(int orderid, int orgid);
        Task<List<f_order_masterModel>> GetOrderedproductDetails(int orderid);
        Task CancleOrder(int orderid);
        Task<MessagesModel> SendMessageVendor(MessagesModel messagesModel);
        Task<MessagesModel> GetUnReadCount(int orgid, string username);
        Task<List<MessagesModel>> Get_Vendor_Message(string userName, int orgid);
    }
}
