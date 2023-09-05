using Microsoft.AspNetCore.Mvc;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Helpers
{
    public class FooterDetailsViewComponent:ViewComponent
    {
        private readonly ICartPageServices _CartPageServices;
        private readonly ICommonHelper _commonHelper;

        List<CartModel> cartModel = new List<CartModel>();

        public FooterDetailsViewComponent(ICartPageServices CartPageServices, ICommonHelper commonHelper)
        {
             // cartModel = cartModel;
            _CartPageServices = CartPageServices;
            _commonHelper = commonHelper;
        }

        [HttpPost]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int orgid = _commonHelper.GetOrgID(HttpContext);
            var FooterDetail = await _CartPageServices.GetVendorDetails(orgid);
           // var model = cartModel;
            return View("FooterDetails", FooterDetail);
        }
    }
}
