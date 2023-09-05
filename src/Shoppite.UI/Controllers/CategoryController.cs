using Microsoft.AspNetCore.Mvc;
using Shoppite.Application.Models;
using Shoppite.Core.Entities;
using Shoppite.UI.Helpers;
using Shoppite.UI.Interfaces;
using Shoppite.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppite.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryPageService _categoryPageService;
        private readonly ICommonHelper _commonHelper;
        public CategoryController(ICategoryPageService categoryPageService, ICommonHelper commonHelper)
        {
            _categoryPageService = categoryPageService ?? throw new ArgumentNullException(nameof(categoryPageService));
            _commonHelper = commonHelper;
        }
        /* public IActionResult Index()
         {

             return View();
         }*/
        /*public async Task<ActionResult> Index(int CategoryId)
        {
            var orgid = commonHelper.GetOrgID(HttpContext);
            var model = new CategoryMasterModel();
            model = await _categoryPageService.DisplayLogo(orgid);
            model.BottomBanner = await _categoryPageService.GetMiddelBannerImage(orgid);
            model.TopBanner = await _categoryPageService.GetTopBannerImage(orgid);
            model.ProductsDetails = await _categoryPageService.GetProductList(orgid);
            model.Categories= await _categoryPageService.GetCategories(CategoryId);
            model.HorizontalBanner = await _categoryPageService.GetHorizontalBanner(orgid);
            return View(model);
        }*/
       /* public async Task<ActionResult> AllCAtegories()
        {
         
            return View();
        }*/
    }
}
