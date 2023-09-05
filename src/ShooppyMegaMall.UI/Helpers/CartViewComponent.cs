using Microsoft.AspNetCore.Mvc;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Helpers
{
    public class CartViewComponent:ViewComponent
    {
        private readonly ICartPageServices _CartPageServices;
        private readonly ICommonHelper _commonHelper;

        List<CartModel> cartModel = new List<CartModel>();

        public CartViewComponent(ICartPageServices CartPageServices, ICommonHelper commonHelper)
        {
            // cartModel = cartModel;
            _CartPageServices = CartPageServices;
            _commonHelper = commonHelper;
           // _commonHelper = commonHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int orgid = _commonHelper.GetOrgID(HttpContext);
            var GetOrderBasic = await _CartPageServices.OrderBasic(orgid);
            var model = cartModel;
            return View("CartShow", GetOrderBasic);
        }
    }
}
