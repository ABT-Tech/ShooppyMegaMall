using Shoppite.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppite.Web.Interfaces
{
    public interface IMyAccountPageService
    {
        Task<f_Get_MyAccount_Data_Model> GetMyAccountDetail(int OrgId, int ProfileId);
        Task UpdateMyAccountDetail(MainModel myaccount);
        Task<MainModel> GetProfileByProfileId(int ProfileId);
        Task ChangePassword(MainModel model);
        Task<int> GetProfileId(string username,int Orgid);
    }
}
