using AutoMapper;
using AutoMapper.Internal.Mappers;
using ShooppyMegaMall.Application.Interfaces;
using ShooppyMegaMall.Application.Mapper;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.Core.Entities;
using ShooppyMegaMall.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<CategoryMasterModel>> GetTopBannerImage(int orgId)
        {
           var image= await _categoryRepository.GetTopBannerImage(orgId);
            var mapped = ObjectMapper.Mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;           
        }
        public async Task<List<CategoryMasterModel>> GetMiddelBannerImage(int orgId)
        {
            var image = await _categoryRepository.GetMiddelBannerImage(orgId);
            var mapped = ObjectMapper.Mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;
        }
        public async Task<IEnumerable<MainCategoryModel>> GetProductList(int orgId)
        {
            List<MainCategoryModel> mainCategory = new List<MainCategoryModel>();
            var mainCatlist = await _categoryRepository.GetProductList(orgId);
            var categories = mainCatlist.GroupBy(x => new { x.maincatid, x.maincaturlpath, }, (key, g) => new { CatId = key.maincatid, Catname = key.maincaturlpath, categories = g.ToList() });
            foreach (var category in categories)
            {
                if (category != null)
                {
                    var Maincat = await _categoryRepository.MaincatDetails(category.CatId, category.Catname);
                    MainCategoryModel mainCategoryModel = new MainCategoryModel();
                    mainCategoryModel.maincatid = category.CatId;
                    mainCategoryModel.maincaturlpath = category.Catname;
                    if (Maincat != null)
                    {
                        mainCategoryModel.IsPublished = Maincat.IsPublished;
                        mainCategoryModel.IsShowHomePage = Maincat.IsShowHomePage;
                        mainCategoryModel.IsIncludeMenu = Maincat.IsIncludeMenu;
                    }

                    mainCategoryModel.SubcategoryDetails = mainCategoryModel.SubcategoryDetails == null ? new List<CategoryProductModel>() : mainCategoryModel.SubcategoryDetails;
                    var childCategories = category.categories.GroupBy(c => new { c.category_name, c.Category_Id }, (key, g) => new { ChildCatId = key.Category_Id, ChildCatname = key.category_name, categories = g.ToList() });
                    foreach (var Product in childCategories)
                    {
                        var ChaildCat = await _categoryRepository.FindChaildCat(Product.ChildCatId, Product.ChildCatname, category.CatId);
                        if (ChaildCat != null)
                        {
                            CategoryProductModel categoryProductModel = new CategoryProductModel();
                            categoryProductModel.CategoryId = Product.ChildCatId;
                            categoryProductModel.CategoryName = Product.ChildCatname;
                            categoryProductModel.IsPublished = ChaildCat.IsPublished;
                            categoryProductModel.IsShowHomePage = ChaildCat.IsShowHomePage;
                            categoryProductModel.IsIncludeMenu = ChaildCat.IsIncludeMenu;

                            mainCategoryModel.SubcategoryDetails.Add(categoryProductModel);
                            categoryProductModel.ProductsDetails = categoryProductModel.ProductsDetails == null ? new List<ProductBaseModel>() : categoryProductModel.ProductsDetails;
                            foreach (var prod in category.categories.Where(a => a.Category_Id.Equals(Product.ChildCatId)))
                            {
                                ProductBaseModel productBaseModel = new ProductBaseModel();
                                productBaseModel.ProductGuid = prod.ProductGUID;
                                productBaseModel.ProductId = prod.ProductId;
                                productBaseModel.ProductName = prod.ProductName;
                                productBaseModel.OldPrice = prod.OldPrice;
                                productBaseModel.Price = prod.Price;
                                productBaseModel.CoverImage = prod.image;
                                categoryProductModel.ProductsDetails.Add(productBaseModel);
                            }

                        }
                        
                    }
                    mainCategory.Add(mainCategoryModel);
                }
            }
                return mainCategory;
        }
        public async Task<List<CategoryMasterModel>> GetCategories(int CategoryId,int OrgId)
        {
            var categories = await _categoryRepository.GetCategories(CategoryId, OrgId);
            var mapped = ObjectMapper.Mapper.Map<List<CategoryMasterModel>>(categories);
            return mapped;
        }
        public async Task<CategoryMasterModel> DisplayLogo(int orgId)
        {
            var logo = await _categoryRepository.DisplayLogo(orgId);
            var mapped = ObjectMapper.Mapper.Map< CategoryMasterModel > (logo);
            return mapped;
        }
        public async Task<List<CategoryMasterModel>> GetBottomBanner(int orgId)
        {
            var image = await _categoryRepository.GetBottomBanner(orgId);
            var mapped = ObjectMapper.Mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;
        }
        public async Task<List<f_getproducts_By_CatID_SpecificationNameModel>> GetAllProductByCategory(int CategoryId, int orgId)
        {
            var products = await _categoryRepository.GetAllProductByCategory(CategoryId,orgId);
            var mapped = ObjectMapper.Mapper.Map<List<f_getproducts_By_CatID_SpecificationNameModel>>(products);
            return mapped;
        }
        public async Task<List<AttributeSetupModel>> GetAllAttributes(int orgID)
        {
            List<AttributeSetupModel> attribute = new List<AttributeSetupModel>();
            var attributes = await _categoryRepository.GetAllAttributes(orgID);
            var specifications = attributes.GroupBy(x => new { x.AttributeName,x.AttributeId}, (key, g) => new { specName=key.AttributeName,specId=key.AttributeId, specific = g.ToList() });
            foreach (var sp in specifications.Take(5))
            {
                AttributeSetupModel specification = new AttributeSetupModel();
                specification.AttributeId = sp.specId;
                specification.AttributeName = sp.specName;
                specification.specifications = specification.specifications == null ? new List<SpecificationSetupModel>() : specification.specifications;
                foreach (var prod in sp.specific.Take(5))
                {
                    SpecificationSetupModel attributespec = new SpecificationSetupModel();
                    attributespec.SpecificationId = prod.SpecificationId;
                    attributespec.SpecificationName = prod.SpecificationName;
                   specification.specifications.Add(attributespec);
                }
                attribute.Add(specification);
            }
            return attribute;
        }
        public async Task<List<f_getproducts_By_CatID_SpecificationNameModel>> GetAllProductByAttribute(int CategoryId, string SpecificationName)
        {
            var attributes = await _categoryRepository.GetAllProductByAttribute(CategoryId, SpecificationName);
            var mapped = ObjectMapper.Mapper.Map<List<f_getproducts_By_CatID_SpecificationNameModel>>(attributes);
            return mapped;
        }
        public async Task<List<CategoryMasterModel>> GetBannerByCategory(int orgId)
        {
            var image = await _categoryRepository.GetBannerByCategory(orgId);
            var mapped = ObjectMapper.Mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;
        }
        public async Task<List<sp_getcat_ResultModel>> GetAllCategories(int orgId)
        {
            var categories = await _categoryRepository.GetAllCategories(orgId);
            var mapped = ObjectMapper.Mapper.Map<List<sp_getcat_ResultModel>>(categories);
            return mapped;
        }
        public async Task<List<CategoryMasterModel>> GetCategoryBannerImage(int orgId)
        {
            var image = await _categoryRepository.GetCategoryBannerImage(orgId);
            var mapped = ObjectMapper.Mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;
        }
        public async Task<List<CategoryMasterModel>> GetLeftBanner(int orgId)
        {
            var image = await _categoryRepository.GetLeftBanner(orgId);
            var mapped = ObjectMapper.Mapper.Map<List<CategoryMasterModel>>(image);
            return mapped;
        }
    }
}
