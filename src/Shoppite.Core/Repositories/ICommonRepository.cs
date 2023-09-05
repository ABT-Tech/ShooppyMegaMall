

using Shoppite.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shoppite.Core.Repositories
{
    public interface ICommonRepository
    {
        int GetOrgID(string OrgName);
    }
}
