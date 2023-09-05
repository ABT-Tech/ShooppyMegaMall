using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Http;
using Shoppite.Application.Interfaces;
using Shoppite.Application.Mapper;
using Shoppite.Application.Models;
using Shoppite.Core.Entities;
using Shoppite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shoppite.Application.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _accessor;
        public WishlistService(IWishlistRepository productRepository, IMapper mapper, IHttpContextAccessor accessor)
        {
            _wishlistRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _accessor = accessor;
        }
        public async Task<List<Customer_WishlistModel>> GetWishList(string Username, int OrgId)
        {
            var wishlist = await _wishlistRepository.GetWishList(Username, OrgId);
            var mapped = ObjectMapper.Mapper.Map<List<Customer_WishlistModel>>(wishlist);
            return mapped;
        }
        public async Task AddWishList(MainModel wishlist, int ProductId)
        {
            var mapped = ObjectMapper.Mapper.Map<CustomerWishlist>(wishlist);
            await _wishlistRepository.AddWishList(mapped, ProductId);

        }
        public async Task<List<f_order_masterDetailsModel>> GetMyOrders(string UserName,int Orgid)
        {
            var orders = await _wishlistRepository.GetMyOrders(UserName, Orgid);
            var mapped = ObjectMapper.Mapper.Map<List<f_order_masterDetailsModel>>(orders);
            return mapped;
        }
        public async Task<List<F_Pending_Orders_Model>> GetPendingOrders(int OrgId, int ProfileId)
        {
            var pendingOrders = await _wishlistRepository.GetPendingOrders(OrgId, ProfileId);
            var mapped = ObjectMapper.Mapper.Map<List<F_Pending_Orders_Model>>(pendingOrders);
            return mapped;
        }
        public async Task<List<F_Pending_Orders_Model>> GetDeliveredOrders(int OrgId, int ProfileId)
        {
            var delivered = await _wishlistRepository.GetDeliveredOrders(OrgId, ProfileId);
            var mapped = ObjectMapper.Mapper.Map<List<F_Pending_Orders_Model>>(delivered);
            return mapped;
        }
        public async Task<List<F_Pending_Orders_Model>> GetCancelledOrders(int OrgId, int ProfileId)
        {
            var Orders = await _wishlistRepository.GetCancelledOrders(OrgId, ProfileId);
            var mapped = ObjectMapper.Mapper.Map<List<F_Pending_Orders_Model>>(Orders);
            return mapped;
        }

        public async Task AddtowhishList(MainModel mainModel)
        {
            var FindProductSpec = await _wishlistRepository.FindProductSpec(mainModel.guid, mainModel.SpecId, mainModel.OrgId);

            CustomerWishlist wishlist = new CustomerWishlist();
            wishlist.ProductId = mainModel.ProductId;
            wishlist.UserName = _accessor.HttpContext.User.Identity.Name;
            wishlist.InsertDate = DateTime.Now;
            wishlist.Ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            wishlist.OrgId = mainModel.OrgId;

            if(FindProductSpec != null)
            wishlist.ProductSpecificationId = FindProductSpec.ProductSpecificationId;

             await _wishlistRepository.AddtoWishList(wishlist);
        }
    }
}
