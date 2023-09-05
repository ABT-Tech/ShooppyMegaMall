using ShoppiteVendor.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppiteVendor.Web.Interfaces
{
    public interface ICategoryPageService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategories();
    }
}
