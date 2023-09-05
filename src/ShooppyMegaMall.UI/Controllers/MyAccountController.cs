using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class MyAccountController : Controller
    {
        private EncryptionHelper eh = new EncryptionHelper();
        private readonly IConfiguration _config;
        private readonly IBrandPageServices _brandPageService;
        private readonly ICategoryPageService _categoryPageService;
        private readonly IMyAccountPageService _myAccountPageService;
        private readonly ILogger<MyAccountController> _logger;
        private readonly ICommonHelper _commonHelper;
        public MyAccountController(IConfiguration config,IBrandPageServices brandPageServices, IMyAccountPageService myAccountPageServices, ICategoryPageService categoryPageService, ILogger<MyAccountController> logger, IWishlistPageService productPageService, IHttpContextAccessor accessor, ICommonHelper commonHelper)
        {
            _myAccountPageService = myAccountPageServices ?? throw new ArgumentNullException(nameof(myAccountPageServices));
            _categoryPageService = categoryPageService ?? throw new ArgumentNullException(nameof(categoryPageService));
            _brandPageService = brandPageServices ?? throw new ArgumentNullException(nameof(brandPageServices));
            _logger = logger ?? throw new ArgumentNullException();
            _commonHelper = commonHelper;
            _config = config;
        }
        [HttpGet]
        public async Task<IActionResult> myAccount(int profileId,int CategoryId)
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            int Profileid = await _myAccountPageService.GetProfileId(User.Identity.Name,OrgId);
            var brands = await _brandPageService.GetBrands(OrgId);
            brands.Categories = await _categoryPageService.GetCategories(CategoryId, OrgId);
            brands.CategoryMaster = await _categoryPageService.DisplayLogo(OrgId);
            brands.ProductsDetails = await _categoryPageService.GetProductList(OrgId);
            brands.Myaccount = await _myAccountPageService.GetMyAccountDetail(OrgId, Profileid);
            return View(brands);
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile(int CategoryId)
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            int Profileid = await _myAccountPageService.GetProfileId(User.Identity.Name,OrgId);
            var brands=await _myAccountPageService.GetProfileByProfileId(Profileid);
            brands.CategoryMaster = await _categoryPageService.DisplayLogo(OrgId);
            brands.Categories = await _categoryPageService.GetCategories(CategoryId, OrgId);
            brands.ProductsDetails = await _categoryPageService.GetProductList(OrgId);
            brands.Myaccount = await _myAccountPageService.GetMyAccountDetail(OrgId, Profileid);
            return View(brands);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(MainModel account)
        {
            //int OrgId = commonHelper.GetOrgID(HttpContext);
            //account.OrgId = OrgId;
            // account.ProfileId = await _myAccountPageService.GetProfileId(User.Identity.Name);


                if (account.ProfileImage != null)
                {
                    account.CoverImage = await UploadProfileImage(account);
                }
                await _myAccountPageService.UpdateMyAccountDetail(account);
            
                return View(account);
        }
        [HttpGet]
        public async Task<IActionResult> ChangePassword(int CategoryId, int ProfileId)
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            int Profileid = await _myAccountPageService.GetProfileId(User.Identity.Name,OrgId);
            var brands = await _myAccountPageService.GetProfileByProfileId(Profileid);
            brands.CategoryMaster = await _categoryPageService.DisplayLogo(OrgId);
            brands.Categories = await _categoryPageService.GetCategories(CategoryId, OrgId);
            brands.ProductsDetails = await _categoryPageService.GetProductList(OrgId);
            brands.Myaccount = await _myAccountPageService.GetMyAccountDetail(OrgId, Profileid);
            return View(brands);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(MainModel model)
        {
             // string Password = model.Password;             \\
            // string encryptedpassword = eh.Encrypt(Password);\\
           //  model.Password = encryptedpassword;              \\
          // model.UserId = 2116;                                \\
            await _myAccountPageService.ChangePassword(model);
            return View(model);
        }
        private async Task<string> UploadProfileImage(MainModel account)
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            string filepath = null;
            try
            {
                AWS_Helper aws = new AWS_Helper(_config);
                if (account.ProfileImage != null)
                {
                    filepath = _config.GetSection("AWSAppSettings")["awsfolderkey"] + OrgId + _config.GetSection("AWSAppSettings")["awscoverimages_Profile"];
                    await aws.uploadfile(account.ProfileImage, filepath);
                }
                return _config.GetSection("AWSAppSettings")["AwsMain_Link"] + filepath + account.ProfileImage.FileName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
