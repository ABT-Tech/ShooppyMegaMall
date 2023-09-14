using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Http;
using ShooppyMegaMall.Application.Interfaces;
using ShooppyMegaMall.Application.Mapper;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.Core.Entities;
using ShooppyMegaMall.Core.Interfaces;
using ShooppyMegaMall.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Application.Services
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepository _CartRepository;
        private readonly IAppLogger<CartServices> _logger;
        private IHttpContextAccessor _accessor;
        public CartServices(ICartRepository CartRepository, IAppLogger<CartServices> appLogger, IHttpContextAccessor accessor)
        {
            _CartRepository = CartRepository ?? throw new ArgumentNullException(nameof(CartRepository));
            _logger = appLogger ?? throw new ArgumentNullException(nameof(appLogger));
            _accessor = accessor;
        }

        public async Task<CartModel> Orderbasic(int orgid)
        {
            if (_accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = _accessor.HttpContext.User.Identity.Name.ToString();

                CartModel orderbasic = new CartModel();
                var Orderbasic = await _CartRepository.OrderBasic(userName);
                orderbasic.F_Getproduct_CartDetails_By_Orgids = ObjectMapper.Mapper.Map<List<f_getproduct_CartDetails_By_OrgidModel>>(Orderbasic).Where(x => x.UserName == userName).ToList();
                //var filter = orderbasic.F_Getproduct_CartDetails_By_Orgids.Where(x => x.UserName == userName).ToList();
                return orderbasic;

            }

            return null;
        }
        public async Task<CartModel> Delete(int id)
        {
            var productDelete = await _CartRepository.DeleteAsync(id);
            var mapped = ObjectMapper.Mapper.Map<CartModel>(productDelete);
            return mapped;
        }

        public async Task SaveAddress(CartModel cartModel)
        {
            cartModel.OrderShippingModel.Contactnumber = cartModel.OrderShippingModel.Phone;
            cartModel.OrderShippingModel.InsertDate = DateTime.Now;
            cartModel.OrderShippingModel.UserName = _accessor.HttpContext.User.Identity.Name;
            cartModel.OrderShippingModel.OrderGuid = cartModel.OrderBasicModel.OrderGuid;

            var maapped = ObjectMapper.Mapper.Map<OrderShipping>(cartModel.OrderShippingModel);
            await _CartRepository.SaveAddress(maapped);
        }

        public async Task UpdateOrderQty(CheckOutModel checkOut)
        {
            foreach (var update in checkOut.ar)
            {
                try
                {
                    Guid guid = Guid.Parse(update.Guid);
                    int qty = Convert.ToInt32(update.Qty);
                    int productId = Convert.ToInt32(update.ProductId);

                    OrderBasic orderBasic = new OrderBasic
                    {
                        OrderGuid = guid,
                        Qty = qty,
                        ProductId = productId, 
                        UserName = _accessor.HttpContext.User.Identity.Name
                    };
                    await _CartRepository.UpdateOrderQty(orderBasic);
                }
                catch (Exception e)
                {

                    throw e;
                }

            }
        }

        public async Task<CartModel> CheckOrder(Guid guid)
        {

            //guid guid = guid.parse(update.guid);
            // int qty = convert.toint32(update.qty);
            CartModel cartModel = new CartModel();
            OrderBasic orderbasic = new OrderBasic
            {
                OrderGuid = guid,
                UserName = _accessor.HttpContext.User.Identity.Name
            };
            var order = await _CartRepository.CheckOrder(orderbasic);
            cartModel.OrderBasicModel = ObjectMapper.Mapper.Map<OrderBasicModel>(order);

            var FindAddress = await _CartRepository.FindAddress(orderbasic.UserName);
            cartModel.UsersProfileModal = ObjectMapper.Mapper.Map<UsersProfileModal>(FindAddress);

            var GetAddress = await _CartRepository.GetAddredd(orderbasic.UserName);
            cartModel.OrderShippingModel = ObjectMapper.Mapper.Map<OrderShippingModel>(GetAddress);

            var orderList = await _CartRepository.GetProductListBYOrder(orderbasic);
            cartModel.OrderBasicModels = ObjectMapper.Mapper.Map<List<OrderBasicModel>>(orderList);

            // cartModel.OrderShippingModel.Contactnumber = cartModel.UsersProfileModal.ContactNumber;
            //cartModel.OrderShippingModel.City = cartModel.UsersProfileModal.City;
            //cartModel.OrderShippingModel.Address = cartModel.UsersProfileModal.Address;
            //cartModel.OrderShippingModel.UserName = cartModel.UsersProfileModal.UserName;

            return cartModel;
        }

        public async Task UpdateOrder(Guid guid)
        {
            OrderBasic orderBasic = new OrderBasic();
            orderBasic.OrderGuid = guid;
            //orderBasic.UserName = _accessor.HttpContext.User.Identity.Name;

            await _CartRepository.UpdateOrder(orderBasic);
        }

        public async Task<UsersProfileModal> GetVendorDetails(int orgid)
        {
            UsersProfile usersProfileModal = new UsersProfile();
            usersProfileModal.OrgId = orgid;
            var userProfile =  await _CartRepository.GetVendorDetails(usersProfileModal);
            return ObjectMapper.Mapper.Map<UsersProfileModal>(userProfile);
        }

        public async Task CancelOrder(Guid guid)
        {
            OrderBasic orderBasic = new OrderBasic();
            orderBasic.OrderGuid = guid;

            await _CartRepository.CancelOrder(orderBasic);
        }
        public async Task<VendorContactDetails> GetVendorContactDetails(Guid guid)
        {
            OrderBasic orderBasic = new OrderBasic();
            orderBasic.OrderGuid = guid;
            var details = await _CartRepository.GetVendorContactDetails(orderBasic.OrderGuid.Value);
            return ObjectMapper.Mapper.Map<VendorContactDetails>(details);
        }
    }
}
