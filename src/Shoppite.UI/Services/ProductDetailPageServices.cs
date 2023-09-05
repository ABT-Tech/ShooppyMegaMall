using AutoMapper;
using Shoppite.Application.Interfaces;
using Shoppite.Application.Models;
using Shoppite.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppite.UI.Services
{
    public class ProductDetailPageServices : IproductDetailPageServices
    {
        private readonly IProductDetailServices _ProductDetailServices;
        private readonly IMapper _mapper;

        public ProductDetailPageServices(IProductDetailServices ProductDetailServices, IMapper mapper)
        {
            _ProductDetailServices = ProductDetailServices ?? throw new ArgumentNullException(nameof(ProductDetailServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddToCart(ProductDetailModel productDetail)
        {
            var mapped = _mapper.Map<ProductDetailModel>(productDetail);
            await _ProductDetailServices.AddToCart(mapped);
        }

        public async Task<ProductDetailModel> BuyNow(ProductDetailModel productDetailModel)
        {
            var mapped = _mapper.Map<ProductDetailModel>(productDetailModel);
            await _ProductDetailServices.BuyNow(mapped);
            return mapped;
        }

        public async Task<ProductDetailModel> GetProductDetails(Guid id,int orgid,string? Username)
        {
            return await _ProductDetailServices.GetProductDetails(id, orgid, Username);
        }

        public async Task<List<ProductDetailModel>> GetproductImages(Guid id)
        {
            return await _ProductDetailServices.GetProductImages(id);
        }

        public async Task<ProductDetailModel> GetProductPrice(Guid id)
        {
            return await _ProductDetailServices.GetProductPrice(id);
        }

        public async Task<List<SP_GetProductDetailsModel>> GetProductVarient(Guid guid, int orgid, int SpecId)
        {
            return await _ProductDetailServices.GetProductVarient(guid, orgid, SpecId);
        }

        public async Task<ProductDetailModel> Get_Brand_Name(Guid guid, int id)
        {
            return await _ProductDetailServices.Get_Brand_Name(guid,id);
        }
        public async Task<ProductDetailModel> ProductAttribute(int AtId)
        {
            return await _ProductDetailServices.ProductAttribute(AtId);
        }
        public async Task Addto_Spec_Product(ProductDetailModel productDetailModel)
        {
            await _ProductDetailServices.Addto_Spec_Product(productDetailModel);
        }
        public async Task<ProductDetailModel> BuyNow_Spec_Product(ProductDetailModel productDetailModel)
        {
            return await _ProductDetailServices.BuyNow_Spec_Product(productDetailModel);
        }
    }
}
