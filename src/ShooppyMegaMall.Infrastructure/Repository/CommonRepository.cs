using ShooppyMegaMall.Core.Repositories;
using ShooppyMegaMall.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooppyMegaMall.Infrastructure.Repository
{
    public class CommonRepository: ICommonRepository
    {
        protected readonly ShooppyMegaMall_masterContext _dbContext;
        public CommonRepository(ShooppyMegaMall_masterContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public int GetOrgID(string OrgName)
        {
            var orgObject = _dbContext.Organization.Where(x => x.OrgName == OrgName).FirstOrDefault();
            if (orgObject != null)
                return orgObject.Id;
            else
                return 0;
        }
    }
}
