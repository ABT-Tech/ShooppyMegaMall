

using ShooppyMegaMall.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Web.Interfaces
{
    public interface ICategoryPageService
    {
        Task<List<CategoryMasterModel>> GetTopBannerImage(int orgId);
        Task<List<CategoryMasterModel>> GetMiddelBannerImage(int orgId);
        Task<IEnumerable<MainCategoryModel>> GetProductList(int orgId);
        Task<List<CategoryMasterModel>> GetCategories(int CAtegoryId,int OrgId);
        Task<CategoryMasterModel> DisplayLogo(int orgId);
        Task<List<CategoryMasterModel>> GetBottomBanner(int orgID);
        Task<List<f_getproducts_By_CatID_SpecificationNameModel>> GetAllProductByCategory(int CategoryId,int OrgId);
        Task<List<f_getproducts_By_CatID_SpecificationNameModel>> GetAllProductByAttribute(int CategoryId,string SpecificationName);
        Task<List<AttributeSetupModel>> GetAllAttributes(int orgId);
        Task<List<CategoryMasterModel>> GetBannerByCategory(int orgId);
        Task<List<sp_getcat_ResultModel>> GetAllCategories(int OrgId);
        Task<List<CategoryMasterModel>> GetCategoryBannerImage(int orgId);
        Task<List<CategoryMasterModel>> GetLeftBanner(int orgId);
    }
}
