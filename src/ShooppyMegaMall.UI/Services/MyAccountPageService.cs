using AutoMapper;
using ShooppyMegaMall.Application.Interfaces;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Services
{
    public class MyAccountPageService:IMyAccountPageService
    {
        private readonly IMyAccountService _myAccountService;
        private readonly IMapper _mapper;
        public MyAccountPageService(IMyAccountService myAccountService, IMapper mapper)
        {
            _myAccountService = myAccountService ?? throw new ArgumentNullException(nameof(myAccountService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<f_Get_MyAccount_Data_Model> GetMyAccountDetail(int orgId,int profileid)
        {
            var myaccount = await _myAccountService.GetMyAccountDetail(orgId, profileid);
            return myaccount;
        }
        public async Task UpdateMyAccountDetail(MainModel myaccount)
        {
            await _myAccountService.UpdateMyAccountDetail(myaccount);
        }
        public async Task<MainModel> GetProfileByProfileId(int profileid)
        {
            return await _myAccountService.GetProfileByProfileId(profileid);
        }
        public async Task ChangePassword(MainModel model)
        {
             await _myAccountService.ChangePassword(model);
        }

        public async Task<int> GetProfileId(string username,int orgid)
        {
            return await _myAccountService.GetProfileId(username, orgid);
        }
    }
}
