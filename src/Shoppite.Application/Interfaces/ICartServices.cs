using Shoppite.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppite.Application.Interfaces
{
    public interface ICartServices
    {
        Task<CartModel> Orderbasic(int orgid);
        Task<CartModel> Delete(int id);
        Task SaveAddress(CartModel cartModel);
        Task UpdateOrder(Guid guid);
        //Task UpdateOrder(CheckOutModel checkOut);
        Task<CartModel> CheckOrder(Guid guid);
        Task UpdateOrderQty(CheckOutModel checkOut);
        Task<UsersProfileModal> GetVendorDetails(int orgid);
        Task CancelOrder(Guid guid);
        Task<VendorContactDetails> GetVendorContactDetails(Guid guid);
    }
}
