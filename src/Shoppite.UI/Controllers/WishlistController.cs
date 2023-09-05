using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shoppite.Application.Models;
using Shoppite.UI.Extensions;
using Shoppite.UI.Helpers;
using Shoppite.UI.Interfaces;
using Shoppite.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppite.UI.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly ICommonHelper _commonHelper;
        private readonly IWishlistPageService _productWishListService;
        private IHttpContextAccessor _accessor;
        private readonly ILogger<WishlistController> _logger;
        private readonly IBrandPageServices _BrandPageService;
        private readonly ICategoryPageService _categoryPageService;
        public WishlistController(IBrandPageServices brandPageServices,ICategoryPageService categoryPageService, ILogger<WishlistController> logger, IWishlistPageService productPageService, IHttpContextAccessor accessor, ICommonHelper commonHelper)
        {
            _accessor = accessor;
            _BrandPageService = brandPageServices ?? throw new ArgumentNullException(nameof(brandPageServices));
            _categoryPageService = categoryPageService ?? throw new ArgumentNullException(nameof(categoryPageService));
            _logger = logger ?? throw new ArgumentNullException();
            _commonHelper = commonHelper;
            _productWishListService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
        }
        [HttpGet]
        public async Task<IActionResult> Wishlist(int CategoryId)
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            string userName = User.Identity.Name;
            var brands = await _BrandPageService.GetBrands(OrgId);
            brands.CategoryMaster = await _categoryPageService.DisplayLogo(OrgId);
            brands.Categories = await _categoryPageService.GetCategories(CategoryId,OrgId);
            brands.ProductsDetails = await _categoryPageService.GetProductList(OrgId);
            brands.Wishlists=await _productWishListService.GetWishList(userName, OrgId);
            return View(brands);
        }
         
        [HttpPost]
        public async Task<IActionResult> Wishlist(MainModel wishlist, int id)
        {
            var ipadresss = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            string userName = User.Identity.Name;
            wishlist.OrgId = OrgId;
            wishlist.Ip = ipadresss;
            wishlist.UserName = userName;  
            await _productWishListService.AddWishList(wishlist, id);
            wishlist.Wishlists = await _productWishListService.GetWishList(userName, OrgId);
            return View(wishlist);
        }
    }
}
