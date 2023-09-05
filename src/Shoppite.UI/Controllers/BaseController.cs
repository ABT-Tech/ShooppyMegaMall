using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Shoppite.UI.Extensions;
using Shoppite.Application.Models;

namespace Shoppite.UI.Controllers
{
    public class BaseController : Controller
    {
        public async Task CreateAuthenticationTicket(UsersModal user)   
        {
            var key = Encoding.ASCII.GetBytes(SiteKeys.Token);
            var JWToken = new JwtSecurityToken(
            issuer: SiteKeys.WebSiteDomain,
            audience: SiteKeys.WebSiteDomain,
            claims: GetUserClaims(user),
            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
          );
            try
            {
               var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                
                 HttpContext.Session.SetString("JWToken", token);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        private IEnumerable<Claim> GetUserClaims(UsersModal user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, user.Email);
            claims.Add(_claim);

            //_claim = new Claim("Role", Role.Admin);
            //claims.Add(_claim);

            return claims.AsEnumerable<Claim>();
        }
    }
}
