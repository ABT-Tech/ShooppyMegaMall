using Microsoft.AspNetCore.Mvc;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Helpers
{
    public class VendorLogoViewComponent:ViewComponent
    {
       // private readonly ICartPageServices _CartPageServices;
        private readonly IAuthenticationsPageService _AuthenticationPageService;
        private readonly ICommonHelper _commonHelper;

        List<CartModel> cartModel = new List<CartModel>();

        public VendorLogoViewComponent(IAuthenticationsPageService AuthenticationPageService, ICommonHelper commonHelper)
        {
            // cartModel = cartModel;
            _AuthenticationPageService = AuthenticationPageService;
             _commonHelper = commonHelper;
        }

        [HttpPost]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int orgid = _commonHelper.GetOrgID(HttpContext);
            var logo = await _AuthenticationPageService.Get_Logo(orgid);
            // var model = cartModel;
            return View("VendorLogo", logo);
        }
    }
}
