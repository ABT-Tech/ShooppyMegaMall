namespace Shoppite.Infrastructure.Repository
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Shoppite.Core.Entities;
    using Shoppite.Core.Repositories;
    using Shoppite.Infrastructure.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ProductDetailRepository" />.
    /// </summary>
    public class ProductDetailRepository : IProductDetailRepsitory
    {
        /// <summary>
        /// Defines the _dbContext.
        /// </summary>
        protected readonly Shoppite_masterContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDetailRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The dbContext<see cref="Shoppite_masterContext"/>.</param>
        public ProductDetailRepository(Shoppite_masterContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// The productBasic.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{ProductBasic}"/>.</returns>
        public async Task<ProductBasic> productBasic(Guid id)
        {
            var productdetails = await _dbContext.ProductBasic.Where(x => x.ProductGuid == id).FirstOrDefaultAsync();
            return productdetails;
        }

        /// <summary>
        /// The ProductImages.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{List{ProductImages}}"/>.</returns>
        public async Task<List<ProductImages>> ProductImages(Guid id)
        {
            var productImages = await _dbContext.ProductImages.Where(x => x.ProductGuid == id).ToListAsync();
            return productImages;
        }

        /// <summary>
        /// The productPrices.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{ProductPrice}"/>.</returns>
        public async Task<ProductPrice> productPrices(Guid id)
        {
            var productprice = await _dbContext.ProductPrice.Where(x => x.ProductGuid == id).FirstOrDefaultAsync();
            return productprice;
        }

        /// <summary>
        /// The Get_Brand_Name.
        /// </summary>
        /// <param name="guid">The guid<see cref="Guid"/>.</param>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{Brands}"/>.</returns>
        public async Task<Brands> Get_Brand_Name(Guid guid, int id)
        {
            var GetBrandName = (from PB in _dbContext.ProductBrands
                                join B in _dbContext.Brands on PB.BrandId equals B.BrandId
                                where PB.ProductGuid == guid
                                select new Brands
                                {
                                    BrandName = B.BrandName,
                                    OrgId = B.OrgId,
                                }).FirstOrDefault();
            return GetBrandName;
        }

        /// <summary>
        /// Defines the catId.
        /// </summary>
        public int catId;

        /// <summary>
        /// The Get_Product_Cat.
        /// </summary>
        /// <param name="guid">The guid<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{ProductCategory}"/>.</returns>
        public async Task<ProductCategory> Get_Product_Cat(Guid guid)
        {
            var GetCat = await _dbContext.ProductCategory.Where(x => x.ProductGuid == guid).FirstOrDefaultAsync();
            catId = (int)GetCat.CategoryId;
            return GetCat;
        }

        /// <summary>
        /// The F_Getproducts_By_CategoryID.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{List{f_getproducts_By_CategoryID}}"/>.</returns>
        public async Task<List<f_getproducts_By_CategoryID>> F_Getproducts_By_CategoryID(int id)
        {
            id = catId;

            string sql = "select * from f_getproducts_By_CategoryID(@ID)";

            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@ID", Value = id }
            };

            return await _dbContext.Set<f_getproducts_By_CategoryID>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();
        }

        /// <summary>
        /// The AddIp.
        /// </summary>
        /// <param name="productRecentlyViewed">The productRecentlyViewed<see cref="ProductRecentlyViewed"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task AddIp(ProductRecentlyViewed productRecentlyViewed)
        {

            var UpdateIp = _dbContext.ProductRecentlyViewed.FirstOrDefault(x => x.ProductId == productRecentlyViewed.ProductId && x.Ip == productRecentlyViewed.Ip);
            if (UpdateIp == null)
            {
                _dbContext.ProductRecentlyViewed.Add(productRecentlyViewed);
            }
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// The GetIP.
        /// </summary>
        /// <param name="orgid">The orgid<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ProductRecentlyViewed}"/>.</returns>
        public async Task<ProductRecentlyViewed> GetIP(int orgid)
        {
            return await _dbContext.ProductRecentlyViewed.Where(x => x.OrgId == orgid).FirstOrDefaultAsync();
        }

        /// <summary>
        /// The F_Getproducts_Recentlyviewed.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <param name="orgid">The orgid<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{List{f_getproducts_Recentlyviewed}}"/>.</returns>
        public async Task<List<f_getproducts_Recentlyviewed>> F_Getproducts_Recentlyviewed(string id, int orgid)
        {
            string sql = "select * from f_getproducts_Recentlyviewed(@IP,@orgid)";

            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@IP", Value = id },
                new SqlParameter { ParameterName = "@orgid", Value = orgid }
            };

            return await _dbContext.Set<f_getproducts_Recentlyviewed>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();
        }

        /// <summary>
        /// The specificationSetups.
        /// </summary>
        /// <param name="SpecGuid">The SpecGuid<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{IEnumerable{f_getproduct_specification_By_Guid}}"/>.</returns>
        public async Task<IEnumerable<f_getproduct_specification_By_Guid>> specificationSetups(Guid SpecGuid)
        {
            string sql = "select * from f_getproduct_specification_By_Guid(@ProductGUID)";

            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@ProductGUID", Value = SpecGuid }
            };
            return await _dbContext.Set<f_getproduct_specification_By_Guid>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();
        }

        /// <summary>
        /// The ProductAttribute.
        /// </summary>
        /// <param name="AtId">The AtId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{IEnumerable{AttributesSetup}}"/>.</returns>
        public async Task<IEnumerable<AttributesSetup>> ProductAttribute(int OrgId)
        {
            var productAttribute = await _dbContext.AttributesSetup.Where(x => x.OrgId== OrgId).ToListAsync();
            return productAttribute;
        }

        /// <summary>
        /// The check.
        /// </summary>
        /// <param name="productDetailModel">The productDetailModel<see cref="OrderBasic"/>.</param>
        /// <returns>The <see cref="Task {OrderBasic}"/>.</returns>
        public async Task<OrderBasic> check(OrderBasic productDetailModel)
        {
            var check = await _dbContext.OrderBasic.Where(x => x.OrderStatus == "Cart" && x.UserName == productDetailModel.UserName && x.OrgId == productDetailModel.OrgId).FirstOrDefaultAsync();
            return check;
        }

        /// <summary>
        /// The AddToCart.
        /// </summary>
        /// <param name="productDetailModel">The productDetailModel<see cref="OrderBasic"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task AddToCart(OrderBasic productDetailModel)
        {
            await _dbContext.OrderBasic.AddAsync(productDetailModel);
   
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateAddToCart(OrderBasic productDetailModel)
        {
            //await _dbContext.SaveChangesAsync();

            var Inventory = await _dbContext.OrderBasic.Where(x => x.ProductId == productDetailModel.ProductId && x.UserName == productDetailModel.UserName && x.OrderGuid == productDetailModel.OrderGuid && x.OrderVariationId == productDetailModel.OrderVariationId).FirstOrDefaultAsync();

            if (Inventory != null)
            {
                var local = _dbContext.Set<OrderBasic>().Local.FirstOrDefault(x => x.ProductId.Equals(Inventory.ProductId) && x.OrderGuid.Equals(Inventory.OrderGuid) && x.UserName.Equals(Inventory.UserName) && x.OrderVariationId.Equals(Inventory.OrderVariationId));
                if (local != null)
                {
                    _dbContext.Entry(local).State = EntityState.Detached;
                }
                Inventory.Qty = productDetailModel.Qty;

                _dbContext.Entry(Inventory).State = EntityState.Modified;
            }
            else
            {
                _dbContext.OrderBasic.Add(productDetailModel);
            }
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// The AddOrderMaster.
        /// </summary>
        /// <param name="orderMaster">The orderMaster<see cref="OrderMaster"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task AddOrderMaster(OrderMaster orderMaster)
        {
            // var check = await _dbContext.OrderMaster.FirstOrDefaultAsync(x => x.OrderGuid == orderMaster.OrderGuid);
            //Guid guid = Guid.NewGuid();
            //orderMaster.OrderGuid = guid;
            //orderMaster.InsertDate = DateTime.Now;

            _dbContext.OrderMaster.Add(orderMaster);
            await _dbContext.SaveChangesAsync();
        }

        public Task<OrderBasic> updateCart()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductVariant>> GetProductVarient(int orgid, Guid id, string username)
        {
            return await _dbContext.ProductVariant.Where(x => x.OrgId == orgid && x.ProductGuid == id).ToListAsync();
        }

        public async Task<List<SP_GetProductDetails>> GetProductVarient(Guid guid, int orgid,int SpecId)
        {
            string sql = "EXEC SP_GetProductDetails @OrgId, @ProductGUID, @SpecificationId";
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{ParameterName = "@OrgId",Value = orgid},
                new SqlParameter{ParameterName = "@ProductGUID",Value = guid},
                new SqlParameter{ParameterName = "@SpecificationId",Value = SpecId}
            };
            return await _dbContext.Set<SP_GetProductDetails>().FromSqlRaw(sql, sqlParameters.ToArray()).ToListAsync();           
        }

        public async Task<List<SP_GetProductSpecifications>> SP_GetProductSpecifications(Guid id, int orgid)
        {
            string Sql = "EXEC SP_GetProductSpecifications @OrgId,@ProductGUID";

            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{ParameterName = "@OrgId",Value = orgid},
                new SqlParameter{ParameterName = "@ProductGUID",Value = id}
            };
            return await _dbContext.Set<SP_GetProductSpecifications>().FromSqlRaw(Sql, sqlParameters.ToArray()).ToListAsync();
        }

        public async Task<ProductSpecification> get_Product_SpecId(Guid? productGuid, int? orgId, int specId)
        {
            var get_Product_SpecId = await _dbContext.ProductSpecification.Where(X => X.ProductGuid == productGuid && X.SpecificationId == specId && X.OrgId == orgId).FirstOrDefaultAsync();
            return get_Product_SpecId;
        }

        public async Task<OrderVariation> Add_Order_Varient(OrderVariation orderVariation)
        {
            var check = await _dbContext.OrderVariation.Where(x => x.OrderGuid == orderVariation.OrderGuid && x.ProductSpecificationId == orderVariation.ProductSpecificationId && x.OrgId == orderVariation.OrgId).FirstOrDefaultAsync();
            if(check == null)
            {
               await _dbContext.OrderVariation.AddAsync(orderVariation);
            }
            await _dbContext.SaveChangesAsync();

            return await _dbContext.OrderVariation.Where(x => x.OrderGuid == orderVariation.OrderGuid && x.ProductSpecificationId == orderVariation.ProductSpecificationId && x.OrgId == orderVariation.OrgId).FirstOrDefaultAsync();
        }

        public async Task<OrderVariation> Get_Order_Varient(OrderVariation orderVariation)
        {
            return await _dbContext.OrderVariation.Where(x => x.OrderGuid == orderVariation.OrderGuid && x.ProductSpecificationId == orderVariation.ProductSpecificationId && x.OrgId == orderVariation.OrgId).FirstOrDefaultAsync();
        }
    }
}
