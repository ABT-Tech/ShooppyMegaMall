using ShooppyMegaMall.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Application.Interfaces
{
    public interface IWishlistService
    {
        Task<List<Customer_WishlistModel>> GetWishList(string Username, int OrgId);
        Task AddWishList(MainModel wishlist, int ProductId);
        Task<List<f_order_masterDetailsModel>> GetMyOrders(string UserName,int Orgid);
        Task<List<F_Pending_Orders_Model>> GetPendingOrders(int orgID, int ProfileId);
        Task<List<F_Pending_Orders_Model>> GetDeliveredOrders(int orgID, int ProfileId);
        Task<List<F_Pending_Orders_Model>> GetCancelledOrders(int orgID, int ProfileId);
        Task AddtowhishList(MainModel mainModel);
    }
}
