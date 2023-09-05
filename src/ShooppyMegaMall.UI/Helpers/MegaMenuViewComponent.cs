using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.UI.Interfaces;
using ShooppyMegaMall.Web.Interfaces;

namespace ShooppyMegaMall.UI.Helpers
{
    public class MegaMenuViewComponent:ViewComponent
    {

        private readonly ICategoryPageService _categoryPageService;
        private readonly ICommonHelper _commonHelper;

        MainModel MainModel = new MainModel();

        public MegaMenuViewComponent(ICategoryPageService categoryPageService, ICommonHelper commonHelper)
        {
            _categoryPageService = categoryPageService;
            _commonHelper = commonHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int orgid = _commonHelper.GetOrgID(HttpContext);
            MainModel.ProductsDetails = await _categoryPageService.GetProductList(orgid);
            MainModel.Categories = await _categoryPageService.GetCategories(0, orgid);
            return View("MegaMenu", MainModel);
        }
    }
}
