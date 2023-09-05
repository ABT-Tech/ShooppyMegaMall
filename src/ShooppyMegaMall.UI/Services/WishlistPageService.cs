using AutoMapper;
using ShooppyMegaMall.Application.Interfaces;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Web.Services
{
    public class WishlistPageService:IWishlistPageService
    {
        private readonly IWishlistService _productWishListService;
        private readonly IMapper _mapper;
        public WishlistPageService(IWishlistService productService, IMapper mapper)
        {
            _productWishListService = productService ?? throw new ArgumentNullException(nameof(productService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<Customer_WishlistModel>> GetWishList(string Username, int OrgId)
        {
            var wishlist = await _productWishListService.GetWishList(Username, OrgId);
            return wishlist;
        }
        public async Task AddWishList(MainModel wishlist, int ProductId)
        {
            await _productWishListService.AddWishList(wishlist, ProductId);

        }
        public async Task<List<f_order_masterDetailsModel>> GetMyOrders(string Username,int Orgid)
        {
            var orders = await _productWishListService.GetMyOrders(Username,Orgid);
            return orders;
        }
        public async Task<List<F_Pending_Orders_Model>> GetPendingOrders(int OrgId, int ProfileId)
        {
            var orders = await _productWishListService.GetPendingOrders(OrgId, ProfileId);
            return orders;
        }
        public async Task<List<F_Pending_Orders_Model>> GetDeliveredOrders(int OrgId, int ProfileId)
        {
            var orders = await _productWishListService.GetDeliveredOrders(OrgId, ProfileId);
            return orders;
        }
        public async Task<List<F_Pending_Orders_Model>> GetCancelledOrders(int OrgId, int ProfileId)
        {
            var orders = await _productWishListService.GetCancelledOrders(OrgId, ProfileId);
            return orders;
        }

        public async Task AddtowhishList(MainModel mainModel)
        {
             await _productWishListService.AddtowhishList(mainModel);
        }
    }
}
