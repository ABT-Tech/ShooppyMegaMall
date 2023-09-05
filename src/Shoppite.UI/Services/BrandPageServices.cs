using AutoMapper;
using Shoppite.Application.Interfaces;
using Shoppite.Application.Models;
using Shoppite.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppite.UI.Services
{
    public class BrandPageServices:IBrandPageServices
    {
        private readonly IBrandServices _BrandService;
        private readonly IMapper _mapper;

        public BrandPageServices(IBrandServices BrandService, IMapper mapper)
        {
            _BrandService = BrandService ?? throw new ArgumentNullException(nameof(BrandService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MainModel> CategoryMater(int orgid)
        {
            return await _BrandService.CategoryMaster(orgid);
        }

        public async Task<MainModel> GetBrands(int orgId)
        {
            return await _BrandService.GetBrands(orgId);
        }

        public async Task<MainModel> GetCategoryBy_Org(int orgId)
        {
            return await _BrandService.GetCategoryBy_Org(orgId);
        }

        public async Task<MainModel> GetnewProduct(int orgid)
        {
            return await _BrandService._Getproducts_By_NewArrivals(orgid);
        }

        public async Task<MainModel> Get_Product_By_Cat(int ID)
        {
            return await _BrandService.Get_Product_By_Cat(ID);
        }

        public async Task<MainModel> Sp_Getcat(int orgid)
        {
            return await _BrandService.Sp_Getcat(orgid);
        }
        public async Task<List<F_getproducts_By_BrandIdModel>> GetProductsByBrand(int orgId, int BrandId)
        {
            var categories = await _BrandService.GetProductsByBrand(orgId, BrandId);
            var mapped = _mapper.Map<List<F_getproducts_By_BrandIdModel>>(categories);
            return mapped;
        }

        public async Task News_Letter_Submit(int orgid, string email)
        {
            await _BrandService.News_Letter_Submit(orgid, email);
        }

        public async Task<List<ProductBasicModel>> SearchProduct(string searchKey,int orgid)
        {
            return await _BrandService.SearchProduct(searchKey,orgid);
        }

        public async Task<OrderModel> GetOrderDetails(int orderid,int orgid)
        {

            return await _BrandService.GetOrderDetails(orderid,orgid);
        }
        public async Task<List<f_order_masterModel>> GetOrderedproductDetails(int orderid)
        {

            return await _BrandService.GetOrderedproductDetails(orderid);
        }

        public async Task CancleOrder(int orderid)
        {
            await _BrandService.CancleOrder(orderid);
        }

        public async Task<MessagesModel> SendMessageVendor(MessagesModel messagesModel)
        {
            return await _BrandService.SendMessageVendor(messagesModel);
        }

        public async Task<List<MessagesModel>> Get_Vendor_Message(string userName, int orgid)
        {
            return await _BrandService.Get_Vendor_Message(userName, orgid);
        }

        public async Task<MessagesModel> GetUnReadCount(int orgid, string username)
        {
            return await _BrandService.GetUnReadCount(orgid, username);
        }
    }
}
