using ShooppyMegaMall.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Application.Interfaces
{
   public  interface IMyAccountService
    {
        Task<List<f_Get_MyAccount_Data_Model>> GetMyAccountDetail(int orgId,int profileid);
        Task UpdateMyAccountDetail(MainModel myaccount);
        Task<MainModel> GetProfileByProfileId(int profileid);
        Task ChangePassword(MainModel model);
        Task<int> GetProfileId(string username,int orgid);
    }
}
