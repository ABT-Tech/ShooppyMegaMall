

using ShooppyMegaMall.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShooppyMegaMall.Core.Repositories
{
    public interface ICommonRepository
    {
        int GetOrgID(string OrgName);
    }
}
