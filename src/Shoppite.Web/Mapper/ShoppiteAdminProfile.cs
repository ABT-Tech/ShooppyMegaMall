using ShoppiteVendor.Application.Models;
using ShoppiteVendor.Web.ViewModels;
using AutoMapper;

namespace ShoppiteVendor.Web.Mapper
{
    public class ShoppiteVendorProfile : Profile
    {
        public ShoppiteVendorProfile()
        {
            CreateMap<ProductModel, ProductViewModel>().ReverseMap();
            CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();
        }
    }
}
