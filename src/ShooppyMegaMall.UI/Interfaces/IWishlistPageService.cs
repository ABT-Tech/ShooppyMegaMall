using ShooppyMegaMall.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Web.Interfaces
{
   public interface IWishlistPageService
    {
        Task<List<Customer_WishlistModel>> GetWishList(string Username, int OrgId);
        Task AddWishList(MainModel wishlsit, int ProductId);
        Task<List<f_order_masterDetailsModel>> GetMyOrders(string UserName, int Orgid);
        Task<List<F_Pending_Orders_Model>> GetPendingOrders(int OrgId, int ProfileId);
        Task<List<F_Pending_Orders_Model>> GetDeliveredOrders(int OrgId, int ProfileId);
        Task<List<F_Pending_Orders_Model>> GetCancelledOrders(int OrgId, int ProfileId);
        Task AddtowhishList(MainModel mainModel);
    }
}
