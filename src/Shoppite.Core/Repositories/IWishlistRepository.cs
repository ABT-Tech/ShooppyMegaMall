using Shoppite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shoppite.Core.Repositories
{
   public  interface IWishlistRepository
    {
        Task<List<SP_UserWishList>> GetWishList(string Username, int OrgId);
        Task AddWishList(CustomerWishlist wishlist, int ProductId);
        Task<List<f_order_masterDetails>> GetMyOrders(string UserName,int Orgid);
        Task<List<F_Pending_Orders>> GetPendingOrders(int OrgId, int ProfileId);
        Task<List<F_Pending_Orders>> GetCancelledOrders(int OrgId, int ProfileId);
        Task<List<F_Pending_Orders>> GetDeliveredOrders(int OrgId, int ProfileId);
        Task AddtoWishList(CustomerWishlist wishlist);
        Task<ProductSpecification> FindProductSpec(Guid? productGuid, int specId, int? orgId);
    }
}
