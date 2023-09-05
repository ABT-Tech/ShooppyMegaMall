﻿using ShooppyMegaMall.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Application.Interfaces
{
    public interface IAuthenticationsService
    {
        public Task<UsersModal> Get_Login_Data(string userName, string passWord);
        public Task<UsersModal> Get_Logo(int orgid);
        Task<UsersModal> RegisterDetail(string userName, string password, string email, int orgId);
        Task<UsersModal> ForgotPass(string email, string password, int orgId);
        Task<UsersModal> Get_Exist_Login_Data(string email, string password, int orgId);
    }
}
