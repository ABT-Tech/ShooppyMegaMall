
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shoppite.Application.Models;
using Shoppite.Core.Entities;
using Shoppite.Core.Repositories;
using Shoppite.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppite.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly Shoppite_masterContext _dbContext;
        public CategoryRepository(Shoppite_masterContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<List<AdsDetail>> GetTopBannerImage(int orgId)
        {
  
            var q = (from ad_detail in _dbContext.AdsDetail
                     join ad_place in _dbContext.AdsPlacement on ad_detail.AdsPlacementId equals ad_place.AdsPlacementId
                     join ad_pagename in _dbContext.AdsPageName on ad_detail.AdsPageId equals ad_pagename.AdsPageId
                     where ad_pagename.PageName=="Home" && ad_place.PlacementName == "Top" && ad_detail.Status == "Active" && ad_detail.OrgId == orgId
                     select ad_detail).ToList();
            return q;
        }
        public async Task<List<AdsDetail>> GetMiddelBannerImage(int orgId)
        {
            var q = (from ad_detail in _dbContext.AdsDetail
                     join ad_place in _dbContext.AdsPlacement on ad_detail.AdsPlacementId equals ad_place.AdsPlacementId
                     join ad_pagename in _dbContext.AdsPageName on ad_detail.AdsPageId equals ad_pagename.AdsPageId
                     where ad_pagename.PageName.Contains("Home") && ad_place.PlacementName == "Middle" && ad_detail.Status=="Active"&& ad_detail.OrgId == orgId
                     select ad_detail).ToList();
            return q;
        }
        public async Task<IEnumerable<f_getproducts_By_CategoryID_Result>> GetProductList(int orgId)
        {
            string sql = "select * from f_cat_getproducts_By_OrgID(@ID)";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@ID", Value = orgId }
            };
             return await _dbContext.Set<f_getproducts_By_CategoryID_Result>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();
            //return f_getproducts_By_CategoryID_ResultList;
        }
        public async Task<List<CategoryMaster>> GetCategories(int CategoryId,int orgId)
        {
            return await _dbContext.CategoryMaster.Where(x=>x.OrgId== orgId).ToListAsync();
        }
        public async Task<Logo> DisplayLogo(int orgId)
        {
            return await _dbContext.Logo.Where(x => x.OrgId == orgId).FirstOrDefaultAsync();
        }
        public async Task<List<AdsDetail>> GetBottomBanner(int orgId)
        {
            var q = (from ad_detail in _dbContext.AdsDetail
                     join ad_place in _dbContext.AdsPlacement on ad_detail.AdsPlacementId equals ad_place.AdsPlacementId
                     join ad_pagename in _dbContext.AdsPageName on ad_detail.AdsPageId equals ad_pagename.AdsPageId
                     where ad_pagename.PageName.Contains("Home") && ad_place.PlacementName == "Bottom" && ad_detail.OrgId == orgId
                     select ad_detail).ToList().TakeLast(1); 
            return q.ToList();
        }
        public async Task<List<F_getproducts_By_CatId>> GetAllProductByCategory(int CategoryId,int Orgid)
        {
            string sql = "select * from f_getproducts_By_CatID(@ID)";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@ID", Value = CategoryId }
            };
            return await _dbContext.Set<F_getproducts_By_CatId>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();
        }
        public async Task<List<SP_GetSpecificationData_AttributName>> GetAllAttributes(int orgID)
        {

            string sql = "exec SP_GetSpecificationData_AttributName @OrgId";
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@OrgId", Value = orgID }
            };
            return await _dbContext.Set<SP_GetSpecificationData_AttributName>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();
        }
        public async Task<List<f_getproducts_By_CatID_SpecificationName>> GetAllProductByAttribute(int CategoryId, string SpecificationName)
        {
            string sql = "select * from f_getproducts_By_CatID_SpecificationName(@ID,@Name)";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@ID", Value = CategoryId },
                new SqlParameter { ParameterName = "@Name", Value = SpecificationName }
            };
            return await _dbContext.Set<f_getproducts_By_CatID_SpecificationName>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();
        }
        public async Task<List<CategoryMaster>> GetBannerByCategory(int orgId)
        {
            var q = (from cm in _dbContext.CategoryMaster where cm.OrgId==orgId
                     select cm).ToList();
            return q;
        }
        public async Task<List<sp_getcat_Result>> GetAllCategories(int orgID)
        {

            string sql = "exec sp_getcat @orgid";
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@orgid", Value = orgID }
            };
            return await _dbContext.Set<sp_getcat_Result>().FromSqlRaw(sql, parms.ToArray()).ToListAsync();
        }

        public async Task<CategoryMaster> MaincatDetails(int? catId, string catname)
        {
            return await _dbContext.CategoryMaster.Where(x => x.CategoryId == catId && x.Urlpath == catname && x.ParentCategoryId == 0).FirstOrDefaultAsync();
        }

        public async Task<CategoryMaster> FindChaildCat(int? childCatId, string childCatname, int? catId)
        {
            return await _dbContext.CategoryMaster.Where(x => x.CategoryId == childCatId && x.CategoryName == childCatname && x.ParentCategoryId == catId).FirstOrDefaultAsync();
        }
        public async Task<List<AdsDetail>> GetCategoryBannerImage(int orgId)
        {

            var q = (from ad_detail in _dbContext.AdsDetail
                     join ad_place in _dbContext.AdsPlacement on ad_detail.AdsPlacementId equals ad_place.AdsPlacementId
                     join ad_pagename in _dbContext.AdsPageName on ad_detail.AdsPageId equals ad_pagename.AdsPageId
                     join categories in _dbContext.CategoryMaster on ad_detail.CategoryId equals categories.CategoryId
                     where  ad_detail.Status == "Active" && ad_detail.OrgId == orgId
                     select ad_detail).ToList();
            return q;
        }
        public async Task<List<AdsDetail>> GetLeftBanner(int orgId)
        {

            var q = (from ad_detail in _dbContext.AdsDetail
                     join ad_place in _dbContext.AdsPlacement on ad_detail.AdsPlacementId equals ad_place.AdsPlacementId
                     join ad_pagename in _dbContext.AdsPageName on ad_detail.AdsPageId equals ad_pagename.AdsPageId
                     where ad_pagename.PageName.Contains("Home") && ad_place.PlacementName == "Left Side" && ad_detail.OrgId == orgId
                     select ad_detail).ToList().TakeLast(1);
            return q.ToList();
        }
    }   
}
