using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.UI.Extensions;
using ShooppyMegaMall.UI.Helpers;
using ShooppyMegaMall.UI.Interfaces;
using ShooppyMegaMall.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Controllers
{
    public class HomeController : Controller
    {
        private IHttpContextAccessor _accessor;
        private readonly ILogger<HomeController> _logger;
        private readonly IBrandPageServices _BrandPageService;
        private readonly IWishlistPageService _wishlistPageService;
        private readonly ICategoryPageService _categoryPageService;
        private readonly ICommonHelper _commonHelper;

        public HomeController(IBrandPageServices brandPageServices, ILogger<HomeController> logger, ICategoryPageService categoryPageService, IHttpContextAccessor accessor,IWishlistPageService wishlistPageService, ICommonHelper commonHelper)
        {
            _accessor = accessor;
            _logger = logger ?? throw new ArgumentNullException();
            _BrandPageService = brandPageServices ?? throw new ArgumentNullException(nameof(brandPageServices));
            _categoryPageService = categoryPageService ?? throw new ArgumentNullException(nameof(categoryPageService));
            _wishlistPageService = wishlistPageService ?? throw new ArgumentNullException(nameof(wishlistPageService));
            _commonHelper = commonHelper;
        }
        public async Task<IActionResult>Index(int CategoryId)
        {
            int OrgId  = _commonHelper.GetOrgID(HttpContext);
            if (OrgId == 0)
            {
                return RedirectToAction("PageNotFound");
            }
            var brands = await _BrandPageService.GetBrands(OrgId);
            brands.CategoryMaster =  await _categoryPageService.DisplayLogo(OrgId);
            brands.MiddelBanner = await _categoryPageService.GetMiddelBannerImage(OrgId);
            brands.TopBanner = await _categoryPageService.GetTopBannerImage(OrgId);
            brands.ProductsDetails = await _categoryPageService.GetProductList(OrgId);
            brands.Categories = await _categoryPageService.GetCategories(CategoryId,OrgId);
            brands.BottomBanner = await _categoryPageService.GetBottomBanner(OrgId);
            brands.BannersByCategory = await _categoryPageService.GetBannerByCategory(OrgId);
            brands.CategoryBanner = await _categoryPageService.GetCategoryBannerImage(OrgId);
            brands.LeftBanner = await _categoryPageService.GetLeftBanner(OrgId);
            return View(brands);
        }
        public async Task<IActionResult> ProductsByBrand(int CategoryId,int BrandId)
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            var brands = await _BrandPageService.GetBrands(OrgId);
            brands.CategoryMaster = await _categoryPageService.DisplayLogo(OrgId);
            brands.MiddelBanner = await _categoryPageService.GetMiddelBannerImage(OrgId);
            brands.TopBanner = await _categoryPageService.GetTopBannerImage(OrgId);
            brands.ProductsDetails = await _categoryPageService.GetProductList(OrgId);
            brands.Categories = await _categoryPageService.GetCategories(CategoryId, OrgId);
            brands.BottomBanner = await _categoryPageService.GetBottomBanner(OrgId);
            brands.BannersByCategory = await _categoryPageService.GetBannerByCategory(OrgId);
            brands.CategoryBanner = await _categoryPageService.GetCategoryBannerImage(OrgId);
            brands.LeftBanner = await _categoryPageService.GetLeftBanner(OrgId);
            brands.ProductdByBrand = await _BrandPageService.GetProductsByBrand(OrgId, BrandId);
            return View(brands);
        }
        public async Task<IActionResult> PageNotFound()
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            if (OrgId == 0)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<JsonResult> Get_Product_By_Cat(int ID)
        {
           var AA = await _BrandPageService.Get_Product_By_Cat(ID);
            return Json(AA.f_getproducts_By_CatIdModel);
        }
        public async Task<IActionResult> AllProducts(int CategoryId)
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            var brands = await _BrandPageService.GetBrands(OrgId);
            brands.CategoryMaster = await _categoryPageService.DisplayLogo(OrgId);
            brands.ProductsDetails = await _categoryPageService.GetProductList(OrgId);
            brands.Categories = await _categoryPageService.GetCategories(CategoryId, OrgId);
            brands.Product_specification = await _categoryPageService.GetAllProductByCategory(CategoryId,OrgId);
            if (User.Identity.Name != null)
            {
              brands.Wishlists = await _wishlistPageService.GetWishList(User.Identity.Name, OrgId);
            }

            brands.Attributes = await _categoryPageService.GetAllAttributes(OrgId);
            brands.AllCategories = await _categoryPageService.GetAllCategories(OrgId);
            return View(brands);
        }
        [HttpGet]
        public async Task<IActionResult> _ProductsByAttribute(int CategoryId, string SpecificationName)
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            MainModel model = new MainModel();
            if(SpecificationName!=null)
            {
                model.Product_specification = await _categoryPageService.GetAllProductByAttribute(CategoryId, SpecificationName);
            }
            else
            {
                model.Product_specification = await _categoryPageService.GetAllProductByCategory(CategoryId,OrgId);
            }
            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> News_Letter_Submit(string email)
        {
            if (email == null || email == "")
            {
                TempData["EmailError"] = "Please Enter Email";
            }
            else
            {
                int orgid = _commonHelper.GetOrgID(HttpContext);
                await _BrandPageService.News_Letter_Submit(orgid, email);
                TempData["EmailError"] = "You Successfully Subscribed to our NewsLetter !!";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> SearchProduct(string SearchKey)
        {
            int orgid = _commonHelper.GetOrgID(HttpContext);

            var SearchResult = await _BrandPageService.SearchProduct(SearchKey,orgid);
            return View(SearchResult);
        }
        public  ActionResult TermsAndCondition()
        {
            return View();
        }
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        public ActionResult MerchantTermsAndCondition()
        {
            return View();
        }
        public ActionResult MerchantPrivacyPolicy()
        {
            return View();
        }
        public ActionResult MerchantRefundPolicy()
        {
            return View();
        }

        public ActionResult ShippingPolicy()
        {
            return View();
        }
    }
}
