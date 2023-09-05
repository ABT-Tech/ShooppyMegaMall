using Shoppite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shoppite.Core.Repositories
{
   public interface IAuthenticationsRepository
    {   
        Task<Users> GetAuthenticato_Details(string email, string password,int orgid);
        Task<Logo> Get_Logo(int orgid);
        Task<Users> RegisterDetail(string userName, string password, string email, int orgId);
        Task<Users> ForgotPass(string email, string password, int orgId);
        Task<Users> Get_Exist_Login_Data(string email, string password);
        Task<Users> AddExistsUser(Users userLogin, int orgId);
        Task Get_Exist_UserProfile_Data(Users userLogin, int orgid);
    }
}
    