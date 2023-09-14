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
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IWishlistPageService _productPageService;
        private readonly ICommonHelper _commonHelper;
        private IHttpContextAccessor _accessor;
        private readonly IMyAccountPageService _myAccountPageService;
        private readonly ILogger<OrdersController> _logger;
        private readonly IBrandPageServices _BrandPageService;
        private readonly ICategoryPageService _categoryPageService;
        public OrdersController(IBrandPageServices brandPageServices, ICategoryPageService categoryPageService, ILogger<WishlistController> logger, IWishlistPageService productPageService, IHttpContextAccessor accessor, ICommonHelper commonHelper, IMyAccountPageService myAccountPageServices)
        {
            _accessor = accessor;
            _BrandPageService = brandPageServices ?? throw new ArgumentNullException(nameof(brandPageServices));
            _categoryPageService = categoryPageService ?? throw new ArgumentNullException(nameof(categoryPageService));
            //_logger = logger ?? throw new ArgumentNullException();
            _productPageService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
            _myAccountPageService = myAccountPageServices ?? throw new ArgumentNullException(nameof(myAccountPageServices));
            _commonHelper = commonHelper;
        }
        [HttpGet]
        public async Task<IActionResult> MyOrders(int CategoryId, string Username)
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            var brands = await _BrandPageService.GetBrands(OrgId);
            //int Profileid = await _myAccountPageService.GetProfileId(User.Identity.Name, OrgId);
            //brands.CategoryMaster = await _categoryPageService.DisplayLogo(OrgId);
            //brands.Categories = await _categoryPageService.GetCategories(CategoryId,OrgId);
            //brands.ProductsDetails = await _categoryPageService.GetProductList(OrgId);
            //brands.Wishlists = await _productPageService.GetWishList(User.Identity.Name, OrgId);
            brands.MyOrderDetails = await _productPageService.GetMyOrders(User.Identity.Name,OrgId);
           // brands.PendingOrders = await _productPageService.GetPendingOrders(OrgId, 1097);
            return View(brands);
        }
        [HttpGet]
        public async Task<IActionResult> _PendingOrders()
        {
            MainModel model = new MainModel();
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            int Profileid = await _myAccountPageService.GetProfileId(User.Identity.Name,OrgId);
            model.MyOrderDetails = await _productPageService.GetMyOrders(User.Identity.Name,OrgId);
            //model.Orders = await _productPageService.GetPendingOrders(OrgId, Profileid);         
            return PartialView(model);
        }
        [HttpGet]
        public async Task<IActionResult> _AllOrders()
        {
            MainModel model = new MainModel();
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            int Profileid = await _myAccountPageService.GetProfileId(User.Identity.Name, OrgId);
            model.MyOrderDetails = await _productPageService.GetMyOrders(User.Identity.Name,OrgId);
            return PartialView(model);
        }
        [HttpGet]
        public async Task<IActionResult> _CancelledOrders()
        {
            MainModel model = new MainModel();
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            int Profileid = await _myAccountPageService.GetProfileId(User.Identity.Name, OrgId);
            model.MyOrderDetails = await _productPageService.GetMyOrders(User.Identity.Name, OrgId);
           // model.Orders = await _productPageService.GetCancelledOrders(OrgId, Profileid);
            return PartialView(model);
        }
        [HttpGet]
        public async Task<IActionResult> _DeliveredOrders()
        {
            MainModel model = new MainModel();
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            int Profileid = await _myAccountPageService.GetProfileId(User.Identity.Name,OrgId);
            model.MyOrderDetails = await _productPageService.GetMyOrders(User.Identity.Name, OrgId);
            //model.Orders = await _productPageService.GetDeliveredOrders(OrgId, Profileid);
            return PartialView(model);
        }
        public async Task<IActionResult> OrderDetails(int orderid)
        {
            OrderModel model = new OrderModel();
            int orgid = _commonHelper.GetOrgID(HttpContext);
            model = await _BrandPageService.GetOrderDetails(orderid,orgid);
            model.MyOrderDetails = await _productPageService.GetMyOrders(User.Identity.Name, orgid);
            model.productDetails = await _BrandPageService.GetOrderedproductDetails(orderid);
            return View(model);
        }
        public async Task<IActionResult> CancleOrder(int orderid)
        {
             await _BrandPageService.CancleOrder(orderid);

            return RedirectToAction(nameof(MyOrders));
        }
    }
}
