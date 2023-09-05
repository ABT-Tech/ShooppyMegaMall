using Microsoft.EntityFrameworkCore;
using ShooppyMegaMall.Core.Entities;
using ShooppyMegaMall.Core.Repositories;
using ShooppyMegaMall.Infrastructure.Data;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Infrastructure.Repository
{
    public class WishlistRepository : IWishlistRepository
    {
        protected readonly ShooppyMegaMall_masterContext _dbContext;
        public WishlistRepository(ShooppyMegaMall_masterContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<List<SP_UserWishList>> GetWishList(string Username, int OrgId)
        {
            string sql = "exec UserWishList @OrgId,@Username";
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@OrgId", Value = OrgId },
                new SqlParameter { ParameterName = "@Username", Value = Username }
            };
            return await _dbContext.Set<SP_UserWishList>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();
        }
        public async Task AddWishList(CustomerWishlist wishlist, int ProductId)
        {
            CustomerWishlist cuswishlist = _dbContext.CustomerWishlist.FirstOrDefault(u => u.WishlistId == ProductId && u.UserName == wishlist.UserName && u.OrgId == wishlist.OrgId);

            if (cuswishlist != null)
            {
                _dbContext.CustomerWishlist.Remove(cuswishlist);
                _dbContext.SaveChanges();
            }           
        }
        public async Task<List<f_order_masterDetails>> GetMyOrders(string username,int Orgid)
        {
            //string sql = "select * from f_My_Orders(@orgid,@profileid)";
            //List<SqlParameter> parms = new List<SqlParameter>
            //{
            //    new SqlParameter { ParameterName = "@orgid", Value = OrgId },
            //    new SqlParameter { ParameterName = "@profileid", Value = profileid }
            //};
            //return await _dbContext.Set<F_Orders_All>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();

            string sql = "select * from f_order_masterDetails()";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                //new SqlParameter { ParameterName = "@orgid", Value = Orgid },
                //new SqlParameter { ParameterName = "@profileid", Value = ProfileId }
            };

          return await _dbContext.Set<f_order_masterDetails>().FromSqlRaw(sql, parms.ToArray()).
                Where( x=>x.UserName == username && x.OrgId == Orgid).ToListAsync();

            //return dataa.Where(x => x.OrderStatus == "Confirmed" && x.UserName == username).ToList();
        }
        public async Task<List<F_Pending_Orders>> GetPendingOrders(int Orgid,int ProfileId)
        {
            string sql = "select * from f_Pending_Orders(@orgid,@profileid)";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@orgid", Value = Orgid },
                new SqlParameter { ParameterName = "@profileid", Value = ProfileId }
            };
            return await _dbContext.Set<F_Pending_Orders>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();

        }
        public async Task<List<F_Pending_Orders>> GetCancelledOrders(int Orgid, int ProfileId)
        {
            string sql = "select * from f_Cancelled_Orders(@orgid,@profileid)";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@orgid", Value = Orgid },
                new SqlParameter { ParameterName = "@profileid", Value = ProfileId }
            };
            return await _dbContext.Set<F_Pending_Orders>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();

        }
        public async Task<List<F_Pending_Orders>> GetDeliveredOrders(int Orgid, int ProfileId)
        {
            string sql = "select * from f_Delivered_Orders(@orgid,@profileid)";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@orgid", Value = Orgid },
                new SqlParameter { ParameterName = "@profileid", Value = ProfileId }
            };
            return await _dbContext.Set<F_Pending_Orders>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();

        }

        public async Task AddtoWishList(CustomerWishlist wishlist)
        {
            var check = await _dbContext.CustomerWishlist.Where(x =>x.ProductId == wishlist.ProductId&&x.OrgId==wishlist.OrgId&&x.UserName==wishlist.UserName && x.ProductSpecificationId == wishlist.ProductSpecificationId).FirstOrDefaultAsync();
           
            if(check == null)
            {
                await _dbContext.CustomerWishlist.AddAsync(wishlist);
            }
            else
            {
                CustomerWishlist cuswishlist = _dbContext.CustomerWishlist.FirstOrDefault(u => u.ProductId == wishlist.ProductId && u.UserName == wishlist.UserName && u.ProductSpecificationId == wishlist.ProductSpecificationId);             
                    _dbContext.CustomerWishlist.Remove(cuswishlist);
                    _dbContext.SaveChanges();               
            }

           await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductSpecification> FindProductSpec(Guid? productGuid, int specId, int? orgId)
        {
            return await _dbContext.ProductSpecification.Where(x => x.ProductGuid == productGuid && x.SpecificationId == specId && x.OrgId == orgId).FirstOrDefaultAsync();
        }
    }
}
