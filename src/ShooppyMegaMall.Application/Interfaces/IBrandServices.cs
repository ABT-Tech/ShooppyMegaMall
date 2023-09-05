using ShooppyMegaMall.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Application.Interfaces
{
    public interface IBrandServices
    {
        public Task<MainModel> GetBrands(int orgid);
        public Task<MainModel> GetCategoryBy_Org(int orgid);
        Task<MainModel> _Getproducts_By_NewArrivals(int orgid);
        Task<MainModel> Sp_Getcat(int orgid);
        Task<MainModel> Get_Product_By_Cat(int ID);
        Task<MainModel> CategoryMaster(int orgid);
        Task<List<ProductDetailModel>> Get_Recently_Product(string id, int orgid);
        Task<List<F_getproducts_By_BrandIdModel>> GetProductsByBrand(int OrgId, int BrandId);
        Task News_Letter_Submit(int orgid, string email);
        Task<List<ProductBasicModel>> SearchProduct(string searchKey, int orgid);
        Task<OrderModel> GetOrderDetails(int orderid,int orgid);
        Task<List<f_order_masterModel>> GetOrderedproductDetails(int orderid);
        Task CancleOrder(int orderid);
        Task<MessagesModel>SendMessageVendor(MessagesModel messagesModel);
        Task<List<MessagesModel>> Get_Vendor_Message(string userName, int orgid);
        Task<MessagesModel> GetUnReadCount(int orgid, string username);
    }
}
