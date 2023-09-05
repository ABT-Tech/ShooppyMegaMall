﻿using Shoppite.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppite.UI.Interfaces
{
   public interface IAuthenticationsPageService
    {
        Task<UsersModal> Get_Login_Data(string username,string password, int orgid);
        Task<UsersModal> Get_Logo(int orgid);
        Task<UsersModal> RegisterDetail(string userName, string password, string email, int orgId);
        Task<UsersModal> ForgotPass(string password, string email, int orgId);
        Core.Entities.Organization GetOrganizationDetails(int orgid);
        Task<UsersModal> Get_Exist_Login_Data(string email, string password, int orgId);
    }
}
