using Microsoft.AspNetCore.Mvc;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Helpers
{
    public class AboutUsViewComponent : ViewComponent
    {
        private readonly IAuthenticationsPageService _AuthenticationsPageService;
        private readonly ICommonHelper _commonHelper;

        public AboutUsViewComponent(ICartPageServices CartPageServices, ICommonHelper commonHelper, IAuthenticationsPageService AuthenticationsPageService)
        {
            // cartModel = cartModel;
            _AuthenticationsPageService = AuthenticationsPageService;
            _commonHelper = commonHelper;
        }

        [HttpPost]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            OrganizationModel organizationModel = new OrganizationModel();
            int orgid = _commonHelper.GetOrgID(HttpContext);
            var OrganizationDetails =  _AuthenticationsPageService.GetOrganizationDetails(orgid);
            if (OrganizationDetails != null)
            {
                organizationModel.Id = OrganizationDetails.Id;
                organizationModel.OrgName = OrganizationDetails.OrgName;
                organizationModel.AboutUs = OrganizationDetails.AboutUs;
            }
            return View("AboutUsDetails", organizationModel);
        }
    }
}
