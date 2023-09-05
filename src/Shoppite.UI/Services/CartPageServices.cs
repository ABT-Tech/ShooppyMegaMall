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
    public class CartPageServices:ICartPageServices
    {
        private readonly ICartServices _CartService;
        private readonly IMapper _mapper;

        public CartPageServices(ICartServices CartService, IMapper mapper)
        {
            _CartService = CartService ?? throw new ArgumentNullException(nameof(CartService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CartModel> OrderBasic(int orgid)
        {
            return await _CartService.Orderbasic(orgid);
        }
        public async Task<CartModel> DeleteAysnc(int id)
        {
            return await _CartService.Delete(id);
        }

        public async Task SaveAddress(CartModel cartModel)
        {
            var mapped = _mapper.Map<CartModel>(cartModel);
            await _CartService.SaveAddress(mapped);
        }

        //public async Task UpdateOrder(CheckOutModel checkOut)
        //{
        //    var mapped = _mapper.Map<CheckOutModel>(checkOut);
        //    await _CartService.UpdateOrder(mapped);

        //}
        public async Task<CartModel> CheckOrder(Guid guid)
        {
           // var mapped = _mapper.Map<CheckOutModel>(guid);
          return await _CartService.CheckOrder(guid);
        }

        public async Task UpdateOrder(Guid guid)
        {
            await _CartService.UpdateOrder(guid);
        }

        public async Task UpdateOrderQty(CheckOutModel checkOut)
        {
            var mapped = _mapper.Map<CheckOutModel>(checkOut);

            await _CartService.UpdateOrderQty(mapped);
        }

        public async Task<UsersProfileModal> GetVendorDetails(int orgid)
        {
            return await _CartService.GetVendorDetails(orgid);
        }

        public async Task CancelOrder(Guid guid)
        {
            await _CartService.CancelOrder(guid);
        }
        public async Task<VendorContactDetails> GetVendorContactDetails(Guid guid)
        {
            return await _CartService.GetVendorContactDetails(guid);
        }
    }
}
