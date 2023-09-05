using Shoppite.Core.Entities;
using Shoppite.Core.Repositories;
using Shoppite.Core.ValueObjects;
using Shoppite.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Shoppite.Infrastructure.Repository
{
    public class AuthenticatiosRepository : IAuthenticationsRepository
    {
        private EncryptionHelper EncryptPass = new EncryptionHelper();
        public string message = "";

        protected readonly Shoppite_masterContext _MasterContext;
        public AuthenticatiosRepository(Shoppite_masterContext dbContext)
        {
            _MasterContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<Users> GetAuthenticato_Details(string email, string password,int orgid)
        {
            string ps = this.EncryptPass.Encrypt(password);
            //var UserValidate =  _MasterContext.Users.Where(x => x.Email == email && x.Password == ps && x.OrgId == orgid).FirstOrDefault();

            var q = await (from user in _MasterContext.Users
                     join userprofile in _MasterContext.UsersProfile on user.Email equals userprofile.UserName 
                     where user.Email == email && user.Password == ps && user.OrgId == orgid && userprofile.Type == "Client"
                     select user).FirstOrDefaultAsync();


            return q;
        }

        public async Task<Logo> Get_Logo(int orgid)
        {
            var logo = await _MasterContext.Logo.Where(x => x.OrgId == orgid).FirstOrDefaultAsync();
            return logo;
        }

        public async Task<Users> RegisterDetail(string userName, string password, string email, int orgId)
        {
            string EnPass = this.EncryptPass.Encrypt(password);
            var check = await _MasterContext.Users.Where(x => x.Email == email && x.OrgId == orgId).FirstOrDefaultAsync();
            var checkProfile = await  _MasterContext.UsersProfile.FirstOrDefaultAsync(x => x.UserName == email && x.OrgId == orgId); 
           if(check == null)
           {
              Users users = new Users();
              users.Username = userName;
              users.Password = EnPass;
              users.Email = email;
              users.OrgId = orgId;
              users.CreatedDate = DateTime.Now;
              users.Guid = Guid.NewGuid();

              await  _MasterContext.Users.AddAsync(users);

                if(checkProfile == null)
                {
                    UsersProfile usersProfile = new UsersProfile();
                    usersProfile.UserName = email;
                    usersProfile.Type = "Client";
                    usersProfile.InsertDate = DateTime.Now;
                    usersProfile.OrgId = orgId;
                    usersProfile.ProfileGuid = users.Guid;
                    usersProfile.Status = "Active";
                    await _MasterContext.UsersProfile.AddAsync(usersProfile);
                }
                

           }
            await _MasterContext.SaveChangesAsync();
            return check;
        }



        public async Task<Users> ForgotPass(string email, string password, int orgId)
        {
            string NewPass = this.EncryptPass.Encrypt(password);
            var findEmail = await _MasterContext.Users.Where(x => x.Email == email && x.OrgId == orgId).FirstOrDefaultAsync();
            if(findEmail != null)
            {
                var local = _MasterContext.Set<Users>().Local.FirstOrDefault(entry => entry.UserId.Equals(findEmail.UserId));

                if (local != null)
                {
                    _MasterContext.Entry(local).State = EntityState.Detached;
                }

                findEmail.Password = NewPass;
                _MasterContext.Entry(findEmail).State = EntityState.Modified;
                await _MasterContext.SaveChangesAsync();
            }

            return findEmail;
        }

        public async Task<Users> Get_Exist_Login_Data(string email, string password)
        {
            string ps = this.EncryptPass.Encrypt(password);
            //var UserValidate =  _MasterContext.Users.Where(x => x.Email == email && x.Password == ps && x.OrgId == orgid).FirstOrDefault();

            var q = await(from user in _MasterContext.Users
                          join userprofile in _MasterContext.UsersProfile on user.Email equals userprofile.UserName
                          where user.Email == email && user.Password == ps && userprofile.Type == "Client"
                          select user).FirstOrDefaultAsync();
            return q;
        }

        public async Task Get_Exist_UserProfile_Data(Users userLogin,int orgid)
        {
            var checkProfile = await _MasterContext.UsersProfile.Where(x => x.UserName == userLogin.Email).FirstOrDefaultAsync();
            if(checkProfile != null)
            {
                checkProfile.OrgId = orgid;
                checkProfile.ProfileId = 0;
                checkProfile.ProfileGuid = userLogin.Guid;
                checkProfile.InsertDate = DateTime.Now;

                await _MasterContext.AddAsync(checkProfile);
            }
            await _MasterContext.SaveChangesAsync();
        }

        public async Task<Users> AddExistsUser(Users userLogin, int orgId)
        {
            var checkUser = await _MasterContext.Users.Where(x => x.Email == userLogin.Email && x.Password == userLogin.Password && x.OrgId == orgId).FirstOrDefaultAsync();

            if (checkUser == null)
            {
                userLogin.OrgId = orgId;
                userLogin.Guid =  Guid.NewGuid();
                userLogin.UserId = 0;
                userLogin.CreatedDate = DateTime.Now;

                 await _MasterContext.AddAsync(userLogin);
                 await _MasterContext.SaveChangesAsync();

               return userLogin;
            }
            return checkUser;
        }
    }
}
