using Microsoft.AspNetCore.Mvc;
using Shoppite.Application.Models;
using Shoppite.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppite.UI.Helpers
{
    public class ChatBotViewComponent: ViewComponent
    {
        MessagesModel messagesModel = new MessagesModel();
        private readonly ICommonHelper _commonHelper;
        private readonly IBrandPageServices _BrandPageService;


        public ChatBotViewComponent(ICommonHelper commonHelper, IBrandPageServices brandPageServices)
        {
            _commonHelper = commonHelper;
            _BrandPageService = brandPageServices;
        }
        [HttpPost]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int orgid = _commonHelper.GetOrgID(HttpContext);
            string username = User.Identity.Name;
            var GetOrderBasic = await _BrandPageService.GetUnReadCount(orgid,username);
            return View("ChatBot", GetOrderBasic);
        }
    }
}
