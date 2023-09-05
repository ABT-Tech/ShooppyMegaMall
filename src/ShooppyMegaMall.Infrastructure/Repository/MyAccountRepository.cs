using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShooppyMegaMall.Core.Entities;
using ShooppyMegaMall.Core.Repositories;
using ShooppyMegaMall.Core.ValueObjects;
using ShooppyMegaMall.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Infrastructure.Repository
{
    public class MyAccountRepository : IMyAccountRepository
    {
        protected readonly ShooppyMegaMall_masterContext _dbContext;
        private EncryptionHelper EncryptPass = new EncryptionHelper();

        public MyAccountRepository(ShooppyMegaMall_masterContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<f_Get_MyAccount_Data> GetMyAccountDetail(int orgId,int profileid)
        {
            string sql = "select * from f_Get_MyAccount_Data(@orgid,@profileid)";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@orgid", Value = orgId },
                 new SqlParameter { ParameterName = "@profileid", Value = profileid }
            };
            return await _dbContext.Set<f_Get_MyAccount_Data>().FromSqlRaw(sql, parms.ToArray()).FirstOrDefaultAsync();
        }
        public async Task UpdateMyAccountDetail(UsersProfile myaccount)
        {
            UsersProfile usersProfile = await _dbContext.UsersProfile.FindAsync(myaccount.ProfileId);
            //usersProfile.UserName = myaccount.UserName;
            usersProfile.CoverImage = myaccount.CoverImage;
            usersProfile.City = myaccount.City;
            usersProfile.State = myaccount.State;
            usersProfile.ContactNumber = myaccount.ContactNumber;
            usersProfile.Address = myaccount.Address;
            usersProfile.City = myaccount.City;
            usersProfile.State = myaccount.State;
            usersProfile.Country = myaccount.Country;

                if (usersProfile != null)
                {
                    _dbContext.Entry(usersProfile).State = EntityState.Detached;
                }
                _dbContext.Entry(usersProfile).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();           
        }
        public async Task<UsersProfile> GetProfileByProfileId(int Profileid)
        {
            var Details = await _dbContext.UsersProfile.Where(x => x.ProfileId == Profileid).FirstOrDefaultAsync();
            return Details;
        }
        public async Task ChangePassword(Users users)
        {
            Users user = await _dbContext.Users.FirstOrDefaultAsync(X=>X.Email == users.Username);

            //usersProfile.UserName = myaccount.UserName;
            string newPass = EncryptPass.Encrypt(users.Password);
            user.Password = newPass;

            if (user != null)
            {
                _dbContext.Entry(user).State = EntityState.Detached;
            }
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetProfileId(string username, int orgid)
        {
            var findUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == username && x.OrgId == orgid);
            var ProfileFind = await _dbContext.UsersProfile.FirstOrDefaultAsync(x => x.UserName == findUser.Email && x.OrgId == orgid);
            return ProfileFind.ProfileId;
        }
    }
}
