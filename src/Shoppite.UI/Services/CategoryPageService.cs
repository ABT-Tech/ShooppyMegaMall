using AutoMapper;
using Shoppite.Application.Interfaces;
using Shoppite.Application.Models;
using Shoppite.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shoppite.Web.Services
{
    public class CategoryPageService : ICategoryPageService
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryPageService(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<CategoryMasterModel>> GetTopBannerImage(int orgId)
        {
            var image = await _categoryService.GetTopBannerImage(orgId);
            var mapped = _mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;
        }
        public async Task<List<CategoryMasterModel>> GetMiddelBannerImage(int orgId)
        {
            var image = await _categoryService.GetMiddelBannerImage(orgId);
            var mapped = _mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;
        }
        public async Task<IEnumerable<MainCategoryModel>> GetProductList(int orgId)
        {
            var productList = await _categoryService.GetProductList(orgId);
            return productList;
        }
        public async Task<List<CategoryMasterModel>> GetCategories(int CategoryId,int OrgId)
        {
            var categories= await _categoryService.GetCategories(CategoryId,OrgId);
            return categories;
        }
        public async Task<CategoryMasterModel> DisplayLogo(int orgId)
        {
            var logo = await _categoryService.DisplayLogo(orgId);
            return logo;
        }
        public async Task<List<CategoryMasterModel>> GetBottomBanner(int orgId)
        {
            var image = await _categoryService.GetBottomBanner(orgId);
            var mapped = _mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;
        }
        public async Task<List<f_getproducts_By_CatID_SpecificationNameModel>> GetAllProductByCategory(int CategoryId,int OrgId)
        {
            var productList = await _categoryService.GetAllProductByCategory(CategoryId,OrgId);
            return productList;
        }
        public async Task<List<AttributeSetupModel>> GetAllAttributes(int orgId)
        {
            var attribute = await _categoryService.GetAllAttributes(orgId);
            return attribute;
        }
        public async Task<List<f_getproducts_By_CatID_SpecificationNameModel>> GetAllProductByAttribute(int CategoryId, string SpecificationName)
        {
            var attribute = await _categoryService.GetAllProductByAttribute(CategoryId, SpecificationName);
            return attribute;
        }
        public async Task<List<CategoryMasterModel>> GetBannerByCategory(int orgId)
        {
            var image = await _categoryService.GetBannerByCategory(orgId);
            var mapped = _mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;
        }
        public async Task<List<sp_getcat_ResultModel>> GetAllCategories(int orgId)
        {
            var categories = await _categoryService.GetAllCategories(orgId);
            var mapped = _mapper.Map<List<sp_getcat_ResultModel>>(categories);
            return mapped;
        }
        public async Task<List<CategoryMasterModel>> GetCategoryBannerImage(int orgId)
        {
            var image = await _categoryService.GetCategoryBannerImage(orgId);
            var mapped = _mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;
        }
        public async Task<List<CategoryMasterModel>> GetLeftBanner(int orgId)
        {
            var image = await _categoryService.GetLeftBanner(orgId);
            var mapped = _mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;
        }
    }
}
