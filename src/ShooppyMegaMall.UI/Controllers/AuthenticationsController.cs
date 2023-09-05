using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.UI.Helpers;
using ShooppyMegaMall.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Controllers
{
    [DataContract]
    public class AuthenticationsController : BaseController
    {
        private readonly IAuthenticationsPageService _AuthenticationPageService;
        private readonly ICommonHelper _commonHelper;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AuthenticationsController(IAuthenticationsPageService AuthenticationPageService, IHostingEnvironment hostingEnvironment, ICommonHelper commonHelper)
        {
            _AuthenticationPageService = AuthenticationPageService ?? throw new ArgumentNullException(nameof(AuthenticationPageService));
            _hostingEnvironment = hostingEnvironment;
            _commonHelper = commonHelper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(int orgid)
        {
            orgid = _commonHelper.GetOrgID(HttpContext);
            var logo = await _AuthenticationPageService.Get_Logo(orgid);
            return View(logo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        //[HttpPost, AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(UsersModal usersModal)
        //{
        //    usersModal.OrgId = commonHelper.GetOrgID(HttpContext);
        //    var UserValidate = await _AuthenticationPageService.Get_Login_Data(usersModal.Username, usersModal.Password, (int)usersModal.OrgId);
        //    if (UserValidate.Password != null && UserValidate.Username != null)
        //    {
        //        _ = CreateAuthenticationTicket(UserValidate);

        //        return RedirectToAction("Index", "Home", new { area = "" });
        //    }
        //    else
        //    {
        //        ViewBag.LoginValidError = "Username or Password is Incorrect";
        //    }
        //    return View(UserValidate);
        //}   public async Task<ActionResult> Login([FromBody] LoginCheckModel loginCheckModel)             var UserValidate = await _AuthenticationPageService.Get_Login_Data(loginCheckModel.datal.userid,loginCheckModel.datal.password,OrgId);


        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> Login(UsersModal usersModal)
        {
            if (usersModal != null)
            {

               // int OrgId = _commonHelper.GetOrgID(HttpContext);
                var UserValidate = await _AuthenticationPageService.Get_Login_Data(usersModal.Email, usersModal.Password);
                if (UserValidate.Password != null && UserValidate.Email != null)
                {
                    await CreateAuthenticationTicket(UserValidate);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["LoginValidError"] = "Username or Password is Incorrect";
                }
            }
            else
            {
              TempData["LoginValidError"] = "User Not Found Please Sign Up";
            }
            //return RedirectToAction("Index","Home", new { area = "" });
            return View(usersModal);
        }


        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> UserExistLogin(UsersModal usersModal)
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            var UserValidate = await _AuthenticationPageService.Get_Exist_Login_Data(usersModal.Exist_Email, usersModal.Exist_Password, OrgId);
            if (UserValidate.Password != null && UserValidate.Email != null)
            {
                await CreateAuthenticationTicket(UserValidate);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginValidError"] = "Username or Password is Incorrect";
            }
            //return RedirectToAction("Index","Home", new { area = "" });
            return View("Login", usersModal);
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> Register(UsersModal usersModal)
        {
            int OrgId = _commonHelper.GetOrgID(HttpContext);
            //if(usersModal.Username)
          var Register = await _AuthenticationPageService.RegisterDetail(usersModal.Username,usersModal.Password,usersModal.Email,OrgId);
        
            if (Register == null)
                return RedirectToAction("Login");
              
            else
                TempData["SignValidError"] = "Email is already exsist";
            //return RedirectToAction("Index","Home", new { area = "" });
            // return Json(loginCheckModel);

            return View(usersModal);
        }

        public async Task<IActionResult> ForgotPassWord()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> ForgotPassWord(UsersModal usersModal)
        {
            if(usersModal.Password == usersModal.ConfPassword)
            {
                int OrgId = _commonHelper.GetOrgID(HttpContext);
                var ForgotPass = await _AuthenticationPageService.ForgotPass(usersModal.Password, usersModal.Email, OrgId);

                if (ForgotPass == null)
                    TempData["EmailValidError"] = "Email not found";
                else
                    return RedirectToAction("Login");
            }
            else
            {
                TempData["PassValidError"] = "Password and Confirm Password not match.";
            }
            
            return View();
        }
    }
}
