using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.UI.Extensions;
using ShooppyMegaMall.UI.Interfaces;
using ShooppyMegaMall.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Controllers
{
    public class InboxController : Controller
    {
        private IHttpContextAccessor _accessor;

        private readonly ILogger<InboxController> _logger;
        private readonly IBrandPageServices _BrandPageService;
        private readonly IWishlistPageService _wishlistPageService;
        private readonly ICategoryPageService _categoryPageService;
        private readonly ICommonHelper _commonHelper;

        public InboxController(IBrandPageServices brandPageServices, ILogger<InboxController> logger, ICategoryPageService categoryPageService, IHttpContextAccessor accessor, IWishlistPageService wishlistPageService, ICommonHelper commonHelper)
        {
            _accessor = accessor;
            _logger = logger ?? throw new ArgumentNullException();
            _BrandPageService = brandPageServices ?? throw new ArgumentNullException(nameof(brandPageServices));
            _categoryPageService = categoryPageService ?? throw new ArgumentNullException(nameof(categoryPageService));
            _wishlistPageService = wishlistPageService ?? throw new ArgumentNullException(nameof(wishlistPageService));
            _commonHelper = commonHelper;
        }

        [HttpPost]
        public async Task<JsonResult> SendBox([FromBody]string Message)
        {
            MessagesModel messagesModel = new MessagesModel();
            messagesModel.OrgId = _commonHelper.GetOrgID(HttpContext);
            messagesModel.Message = Message;
            messagesModel.Sender = User.Identity.Name;

            var sendVendor = await _BrandPageService.SendMessageVendor(messagesModel);
            return Json(sendVendor);
        }
        [HttpGet]
        public async Task<JsonResult> Get_Vendor_Message(string UserName)
        {
            int orgid = _commonHelper.GetOrgID(HttpContext);
            var Get_Vendor_Message = await _BrandPageService.Get_Vendor_Message(UserName, orgid);
            return Json(Get_Vendor_Message);
        }
    }
}
