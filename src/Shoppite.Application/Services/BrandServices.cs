using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Http;
using Shoppite.Application.Interfaces;
using Shoppite.Application.Mapper;
using Shoppite.Application.Models;
using Shoppite.Core.Entities;
using Shoppite.Core.Interfaces;
using Shoppite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppite.Application.Services
{
    public class BrandServices : IBrandServices
    {
        private readonly IBrandRepository _BrandRepository;
        private readonly IAppLogger<BrandServices> _logger;
        private IHttpContextAccessor _accessor;
        public BrandServices(IBrandRepository brandRepository, IAppLogger<BrandServices> appLogger, IHttpContextAccessor accessor)
        {
            _BrandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _logger = appLogger ?? throw new ArgumentNullException(nameof(appLogger));
            _accessor = accessor;
        }

        public async Task<MainModel> CategoryMaster(int orgid)
        {
            MainModel main = new MainModel();
            var CategoryMaster = await _BrandRepository.CategoryMaster(orgid);
            main.CategoryMasterModel = ObjectMapper.Mapper.Map<List<CategoryMasterModel>>(CategoryMaster);
            return main;
        }

        public async Task<MainModel> GetBrands(int orgid)
        {
            MainModel main = new MainModel();

            var Get_Cat_List = await _BrandRepository.Sp_Getcat(orgid);
            main.GetSp_Getcat_ResultModel = ObjectMapper.Mapper.Map<List<sp_getcat_ResultModel>>(Get_Cat_List);

            var brands = await _BrandRepository.GetBrands(orgid);
             main.BrandsModel = ObjectMapper.Mapper.Map<List<BrandsModel>>(brands);

            //var GetCategoryByOrg = await _BrandRepository.GetCategoryBy_Org(orgid);
            //main.f_Getproducts_By_OrgIDModel = ObjectMapper.Mapper.Map<List<f_getproducts_By_OrgIDModel>>(GetCategoryByOrg);

            var getnewProduct = await _BrandRepository._Getproducts_By_NewArrivals(orgid);
            main.ProductNewArrivalModel = ObjectMapper.Mapper.Map<List<f_getproducts_By_NewArrivalsModel>>(getnewProduct);

            string ipAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

            var ProductRecent = await _BrandRepository.F_Getproducts_Recentlyviewed(ipAddress, orgid);
            main.f_Getproducts_RecentlyviewedModel = ObjectMapper.Mapper.Map<List<f_getproducts_RecentlyviewedModel>>(ProductRecent);

            // var CategoryMaster = await _BrandRepository.CategoryMaster(orgid);
            // main.CategoryMasterModel = ObjectMapper.Mapper.Map<List<CategoryMasterModel>>(CategoryMaster);

            return main;
        }

        public async Task<MainModel> GetCategoryBy_Org(int orgid)
        {
            MainModel main = new MainModel();
            var GetNewProducts = await _BrandRepository.GetCategoryBy_Org(orgid);
            main.ProductNewArrivalModel = ObjectMapper.Mapper.Map<List<f_getproducts_By_NewArrivalsModel>>(GetNewProducts);
            return main;
        }

        public async Task<MainModel> Get_Product_By_Cat(int ID)
        {
            MainModel main = new MainModel();
            var Product_By_Cat = await _BrandRepository.Get_Product_By_Cat(ID);
            main.f_getproducts_By_CatIdModel = ObjectMapper.Mapper.Map<List<F_getproducts_By_CatIdModel>>(Product_By_Cat);
            return main;
        }

        public async Task<MainModel> Sp_Getcat(int orgid)
        {
            MainModel main = new MainModel();
            var Get_Cat_List = await _BrandRepository.Sp_Getcat(orgid);
            main.GetSp_Getcat_ResultModel = ObjectMapper.Mapper.Map<List<sp_getcat_ResultModel>>(Get_Cat_List);
            return main;
        }

        public async Task<MainModel> _Getproducts_By_NewArrivals(int orgid)
        {
            MainModel main = new MainModel();
            var getnewProduct = await _BrandRepository._Getproducts_By_NewArrivals(orgid);
            main.ProductNewArrivalModel = ObjectMapper.Mapper.Map<List<f_getproducts_By_NewArrivalsModel>>(getnewProduct);
            return main;
        }
        public async Task<List<ProductDetailModel>> Get_Recently_Product(string id, int orgid)
        {
            ProductDetailModel productDetailModel = new ProductDetailModel();
            var ProductCatId = await _BrandRepository.F_Getproducts_Recentlyviewed(id, orgid);
            productDetailModel.f_Getproducts_RecentlyviewedModel = ObjectMapper.Mapper.Map<List<f_getproducts_RecentlyviewedModel>>(ProductCatId);
            return null;
        }
        public async Task<List<F_getproducts_By_BrandIdModel>> GetProductsByBrand(int orgId,int BrandId)
        {
            var categories = await _BrandRepository.GetProductsByBrand(orgId,BrandId);
            var mapped = ObjectMapper.Mapper.Map<List<F_getproducts_By_BrandIdModel>>(categories);
            return mapped;
        }

        public async Task News_Letter_Submit(int orgid, string email)
        {
            await _BrandRepository.News_Letter_Submit(orgid, email);
        }

        public async Task<List<ProductBasicModel>> SearchProduct(string searchKey, int orgid)
        {
            ProductBasicModel productBasicModel = new ProductBasicModel();
            var SearchResult = await _BrandRepository.SearchProduct(searchKey,orgid);
           var mapped =  ObjectMapper.Mapper.Map<List<ProductBasicModel>>(SearchResult);

            foreach(var prices in mapped)
            {
                var price = await _BrandRepository.GetPrice((Guid)prices.ProductGuid);
                productBasicModel.ProductPricemodel = ObjectMapper.Mapper.Map<ProductPriceModel>(price);
                prices.OldPrice = productBasicModel.ProductPricemodel.OldPrice;
                prices.Price = productBasicModel.ProductPricemodel.Price;
            }

            return mapped;
        }

        public async Task<OrderModel> GetOrderDetails(int orderid,int orgid)
        {
            OrderModel orderModel = new OrderModel();

            var orders = await _BrandRepository.GetMyOrders(orderid);
            orderModel.f_Order_MasterModel = ObjectMapper.Mapper.Map<f_order_masterModel>(orders);

            var getShippingDetail = await _BrandRepository.GetShippingDetail(orderModel.f_Order_MasterModel.UserName,orgid);
            orderModel.UsersProfileModel = ObjectMapper.Mapper.Map<UsersProfileModal>(getShippingDetail);

            var GetProductDetail = await _BrandRepository.GetProductDetail(orderModel.f_Order_MasterModel.ProductName, orderModel.f_Order_MasterModel.CoverImage);
            orderModel.ProductBasicModel = ObjectMapper.Mapper.Map<List<ProductBasicModel>>(GetProductDetail);

            var GetOrderSATUS = await _BrandRepository.GetOrderStatus(orderid,orgid);
            orderModel.OrderStatusModel = ObjectMapper.Mapper.Map<OrderStatusModel>(GetOrderSATUS);

            var getUsername = await _BrandRepository.GetUser(orderModel.f_Order_MasterModel.UserName,orgid);
            orderModel.UserName = getUsername.Username;

            return orderModel;
        }
        public async Task<List<f_order_masterModel>> GetOrderedproductDetails(int orderid)
        {
            List<f_order_masterModel> orderModel = new List<f_order_masterModel>();

            var productsDetails = await _BrandRepository.GetOrderedproductDetails(orderid);
            orderModel= ObjectMapper.Mapper.Map<List<f_order_masterModel>>(productsDetails);
            return orderModel;
        }

        public async Task CancleOrder(int orderid)
        {
            await _BrandRepository.CancleOrder(orderid);
        }

        public async Task<MessagesModel> SendMessageVendor(MessagesModel messagesModel)
        {
            var getOrg = await _BrandRepository.GetOrg(messagesModel.OrgId);

            Messages messages = new Messages
            {
                ChatId = Guid.NewGuid(),
                Recipient = getOrg.VEmail,
                Senddate = DateTime.Now,
                Status = "UnRead",
                OrgId = messagesModel.OrgId,
                Sender = messagesModel.Sender,
                Message = messagesModel.Message,
            };

            var SendVendor = await _BrandRepository.SendMessageVendor(messages);

          return messagesModel = ObjectMapper.Mapper.Map<MessagesModel>(SendVendor);
            
        }

        public async Task<List<MessagesModel>> Get_Vendor_Message(string userName, int orgid)
        {
            List<MessagesModel> messagesModel = new List<MessagesModel>();
            var Get_Vendor_Message = await _BrandRepository.Get_Vendor_Message(userName, orgid);
          return messagesModel = ObjectMapper.Mapper.Map<List<MessagesModel>>(Get_Vendor_Message);
        }

        public async Task<MessagesModel> GetUnReadCount(int orgid, string username)
        {
            MessagesModel messagesModel = new MessagesModel();
            var GetUnReadCount = await _BrandRepository.GetUnReadCount(orgid, username);
            messagesModel.MessagesModelList = ObjectMapper.Mapper.Map<List<MessagesModel>>(GetUnReadCount);
            return messagesModel;
        }
    }
}
