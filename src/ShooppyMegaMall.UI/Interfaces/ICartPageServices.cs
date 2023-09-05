using ShooppyMegaMall.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Interfaces
{
   public interface ICartPageServices
    {
        Task<CartModel>OrderBasic(int orgid);
        Task<CartModel> DeleteAysnc(int id);
        Task SaveAddress(CartModel cartModel);
        //Task UpdateOrder(CheckOutModel checkOut);
        Task<CartModel> CheckOrder(Guid guid);
        Task UpdateOrder(Guid guid);
        Task UpdateOrderQty(CheckOutModel checkOut);
        Task<UsersProfileModal> GetVendorDetails(int orgid);
        Task CancelOrder(Guid guid);
        Task<VendorContactDetails> GetVendorContactDetails(Guid guid);
    }
}
