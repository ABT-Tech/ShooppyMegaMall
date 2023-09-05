using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Shoppite.Application.Interfaces;
using Shoppite.Application.Models;
using Shoppite.UI.Interfaces;
using Shoppite.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppite.UI.Services
{
    public class AuthenticationPageService : IAuthenticationsPageService
    {
        private readonly IAuthenticationsService _AuthenticationService;
        private readonly IMapper _mapper;
        private readonly ICommonHelper _commonHelper;
        private readonly ILogger<AuthenticationPageService> _logger;

        public AuthenticationPageService(IAuthenticationsService AuthenticationAppService, IMapper mapper, ILogger<AuthenticationPageService> logger, ICommonHelper commonHelper)
        {
            _AuthenticationService = AuthenticationAppService ?? throw new ArgumentNullException(nameof(AuthenticationAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commonHelper = commonHelper;
        }

        public async Task<UsersModal> ForgotPass(string password, string email, int orgId)
        {
            return await _AuthenticationService.ForgotPass(email, password, orgId);
        }

        public async Task<UsersModal> Get_Login_Data(string email, string password, int orgid)
        {
            return await _AuthenticationService.Get_Login_Data(email, password, orgid);
        }

        public async Task<UsersModal> Get_Logo(int orgid)
        {
            return await _AuthenticationService.Get_Logo(orgid);
        }

        public async Task<UsersModal> RegisterDetail(string userName, string password, string email, int orgId)
        {
          return await _AuthenticationService.RegisterDetail(userName, password, email, orgId);
        }

        public Core.Entities.Organization GetOrganizationDetails(int orgid)
        {
            return _commonHelper.OrganizationDetails(orgid);
        }

        public async Task<UsersModal> Get_Exist_Login_Data(string email, string password, int orgId)
        {
            return await _AuthenticationService.Get_Exist_Login_Data(email, password, orgId);
        }
    }
}
