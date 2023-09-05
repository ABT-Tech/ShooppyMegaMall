namespace Shoppite.Application.Services
{
    using Microsoft.AspNetCore.Http;
    using Shoppite.Application.Interfaces;
    using Shoppite.Application.Mapper;
    using Shoppite.Application.Models;
    using Shoppite.Core.Entities;
    using Shoppite.Core.Interfaces;
    using Shoppite.Core.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ProductDetilServices" />.
    /// </summary>
    public class ProductDetilServices : IProductDetailServices
    {
        /// <summary>
        /// Defines the _ProductDetailRepsitory.
        /// </summary>
        private readonly IProductDetailRepsitory _ProductDetailRepsitory;
        private readonly IWishlistRepository _wishlistRepository;
        private readonly ICartRepository _CartRepository;

        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly IAppLogger<ProductDetilServices> _logger;

        /// <summary>
        /// Defines the _accessor.
        /// </summary>
        private IHttpContextAccessor _accessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDetilServices"/> class.
        /// </summary>
        /// <param name="ProductDetailRepsitory">The ProductDetailRepsitory<see cref="IProductDetailRepsitory"/>.</param>
        /// <param name="appLogger">The appLogger<see cref="IAppLogger{ProductDetilServices}"/>.</param>
        /// <param name="accessor">The accessor<see cref="IHttpContextAccessor"/>.</param>
        public ProductDetilServices(IWishlistRepository wishlistRepository, IProductDetailRepsitory ProductDetailRepsitory, IAppLogger<ProductDetilServices> appLogger, ICartRepository CartRepository, IHttpContextAccessor accessor)
        {
            _ProductDetailRepsitory = ProductDetailRepsitory ?? throw new ArgumentNullException(nameof(ProductDetailRepsitory));
            _logger = appLogger ?? throw new ArgumentNullException(nameof(appLogger));
            _CartRepository = CartRepository ?? throw new ArgumentNullException(nameof(CartRepository));
            _wishlistRepository = wishlistRepository ?? throw new ArgumentNullException(nameof(wishlistRepository));
            _accessor = accessor;
        }

        /// <summary>
        /// The GetProductDetails.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <param name="orgid">The orgid<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ProductDetailModel}"/>.</returns>
        public async Task<ProductDetailModel> GetProductDetails(Guid id, int orgid,string username)
        {
            int x = 1;
            ProductDetailModel productDetailModel = new ProductDetailModel();
            var productDetail = await _ProductDetailRepsitory.productBasic(id);
            productDetailModel.ProductBasicModel = ObjectMapper.Mapper.Map<ProductBasicModel>(productDetail);
            if(username!=null)
            {
                var wishlist = await _wishlistRepository.GetWishList(username, orgid);
                productDetailModel.Wishlists = ObjectMapper.Mapper.Map<List<Customer_WishlistModel>>(wishlist);
            }                         
            var ProductImages = await _ProductDetailRepsitory.ProductImages(id);
            productDetailModel.ProductImagesModel = ObjectMapper.Mapper.Map<List<ProductImagesModel>>(ProductImages);

            var ProductPrice = await _ProductDetailRepsitory.productPrices(id);
            productDetailModel.ProductPriceModel = ObjectMapper.Mapper.Map<ProductPriceModel>(ProductPrice);

            var Brand_Name = await _ProductDetailRepsitory.Get_Brand_Name(id, x);
            productDetailModel.BrandsModel = ObjectMapper.Mapper.Map<BrandsModel>(Brand_Name);

            var ProductCatId = await _ProductDetailRepsitory.Get_Product_Cat(id);
            productDetailModel.ProductCategoryModel = ObjectMapper.Mapper.Map<ProductCategoryModel>(ProductCatId);

            var Product_By_Cat = await _ProductDetailRepsitory.F_Getproducts_By_CategoryID(x);
            productDetailModel.f_Getproducts_By_CategoryIDModels = ObjectMapper.Mapper.Map<List<f_getproducts_By_CategoryIDModel>>(Product_By_Cat);

            var SP_GetProductSpecifications = await _ProductDetailRepsitory.SP_GetProductSpecifications(id, orgid);
            productDetailModel.Sp_GetProductSpecificationsModels = ObjectMapper.Mapper.Map<List<SP_GetProductSpecificationsModel>>(SP_GetProductSpecifications);

            var productAttribute = await _ProductDetailRepsitory.ProductAttribute(orgid);
            productDetailModel.AttributesSetupModel = ObjectMapper.Mapper.Map<List<AttributesSetupModel>>(productAttribute);

            var ProductVariant = await _ProductDetailRepsitory.GetProductVarient(orgid, id, username);
            productDetailModel.productVariantModel = ObjectMapper.Mapper.Map<List<ProductVariantModel>>(ProductVariant);


            var productSpecVal = await _ProductDetailRepsitory.specificationSetups(id);
            var spectype = ObjectMapper.Mapper.Map<List<f_getproduct_specification_By_GuidModel>>(productSpecVal);
            foreach (var prodAttr in productDetailModel.AttributesSetupModel)
            {
                prodAttr.GetF_Getproduct_Specification_By_GuidModel = spectype.ToList();
            }
            string ipAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();



            ProductRecentlyViewed productRecently = new ProductRecentlyViewed();
            productRecently.Ip = ipAddress;
            productRecently.ProductId = productDetailModel.ProductBasicModel.ProductId;
            productRecently.Insertdate = DateTime.Now;
            productRecently.OrgId = productDetailModel.ProductBasicModel.OrgId;

            var productRecent = ObjectMapper.Mapper.Map<ProductRecentlyViewed>(productRecently);
            await _ProductDetailRepsitory.AddIp(productRecent);

            //var ProductRecent = await _ProductDetailRepsitory.F_Getproducts_Recentlyviewed(ipAddress, orgid);
            //productDetailModel.f_Getproducts_RecentlyviewedModel = ObjectMapper.Mapper.Map<List<f_getproducts_RecentlyviewedModel>>(ProductRecent);
            if(productDetailModel.Wishlists!=null)
            {
                for (int i = 0; i < productDetailModel.Wishlists.Count; i++)
                {
                    if (productDetailModel.ProductBasicModel.ProductId == productDetailModel.Wishlists[i].ProductId)
                    {
                        productDetailModel.ProductBasicModel.WishlistedProduct = true;

                    }
                }

            }
            
            return productDetailModel;
        }

        /// <summary>
        /// The GetProductImages.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{List{ProductDetailModel}}"/>.</returns>
        public async Task<List<ProductDetailModel>> GetProductImages(Guid id)
        {
            ProductDetailModel productDetailModel = new ProductDetailModel();

            var ProductImages = await _ProductDetailRepsitory.ProductImages(id);
            productDetailModel.ProductImagesModel = ObjectMapper.Mapper.Map<List<ProductImagesModel>>(ProductImages);

            return null;
        }

        /// <summary>
        /// The GetProductPrice.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{ProductDetailModel}"/>.</returns>
        public async Task<ProductDetailModel> GetProductPrice(Guid id)
        {
            ProductDetailModel productDetailModel = new ProductDetailModel();

            var ProductPrice = await _ProductDetailRepsitory.productPrices(id);
            productDetailModel.ProductPriceModel = ObjectMapper.Mapper.Map<ProductPriceModel>(ProductPrice);

            return productDetailModel;
        }

        /// <summary>
        /// The Get_Brand_Name.
        /// </summary>
        /// <param name="guid">The guid<see cref="Guid"/>.</param>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ProductDetailModel}"/>.</returns>
        public async Task<ProductDetailModel> Get_Brand_Name(Guid guid, int id)
        {
            ProductDetailModel productDetailModel = new ProductDetailModel();
            var Brand_Name = await _ProductDetailRepsitory.Get_Brand_Name(guid, id);
            productDetailModel.BrandsModel = ObjectMapper.Mapper.Map<BrandsModel>(Brand_Name);
            return productDetailModel;
        }

        /// <summary>
        /// The Get_Product_Cat.
        /// </summary>
        /// <param name="guid">The guid<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{ProductDetailModel}"/>.</returns>
        public async Task<ProductDetailModel> Get_Product_Cat(Guid guid)
        {
            ProductDetailModel productDetailModel = new ProductDetailModel();
            var ProductCatId = await _ProductDetailRepsitory.Get_Product_Cat(guid);
            productDetailModel.ProductCategoryModel = ObjectMapper.Mapper.Map<ProductCategoryModel>(ProductCatId);
            return productDetailModel;
        }

        /// <summary>
        /// The Get_Similar_Product.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{List{ProductDetailModel}}"/>.</returns>
        public async Task<List<ProductDetailModel>> Get_Similar_Product(int id)
        {
            ProductDetailModel main = new ProductDetailModel();
            var Product_By_Cat = await _ProductDetailRepsitory.F_Getproducts_By_CategoryID(id);
            main.f_Getproducts_By_CategoryIDModels = ObjectMapper.Mapper.Map<List<f_getproducts_By_CategoryIDModel>>(Product_By_Cat);
            return null;
        }

        /// <summary>
        /// The AddIp.
        /// </summary>
        /// <param name="detailModel">The detailModel<see cref="ProductDetailModel"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task AddIp(ProductDetailModel detailModel)
        {
            var productRecent = ObjectMapper.Mapper.Map<ProductRecentlyViewed>(detailModel.ProductRecentlyViewedModel);
            await _ProductDetailRepsitory.AddIp(productRecent);
        }

        /// <summary>
        /// The GetIP.
        /// </summary>
        /// <param name="orgid">The orgid<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ProductDetailModel}"/>.</returns>
        public async Task<ProductDetailModel> GetIP(int orgid)
        {
            ProductDetailModel main = new ProductDetailModel();
            var GetNewProducts = await _ProductDetailRepsitory.GetIP(orgid);
            main.ProductRecentlyViewedModel = ObjectMapper.Mapper.Map<ProductRecentlyViewedModel>(GetNewProducts);
            return main;
        }

        /// <summary>
        /// The Get_Recently_Product.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <param name="orgid">The orgid<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{List{ProductDetailModel}}"/>.</returns>
        public async Task<List<ProductDetailModel>> Get_Recently_Product(string id, int orgid)
        {
            ProductDetailModel productDetailModel = new ProductDetailModel();
            var ProductCatId = await _ProductDetailRepsitory.F_Getproducts_Recentlyviewed(id, orgid);
            productDetailModel.f_Getproducts_RecentlyviewedModel = ObjectMapper.Mapper.Map<List<f_getproducts_RecentlyviewedModel>>(ProductCatId);
            return null;
        }

        /// <summary>
        /// The ProductAttribute.
        /// </summary>
        /// <param name="AtId">The AtId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ProductDetailModel}"/>.</returns>
        public async Task<ProductDetailModel> ProductAttribute(int AtId)
        {
            ProductDetailModel productModel = new ProductDetailModel();
            var productAttribute = await _ProductDetailRepsitory.ProductAttribute(AtId);
            productModel.AttributesSetupModel = ObjectMapper.Mapper.Map<List<AttributesSetupModel>>(productAttribute);
            return productModel;
        }

        /// <summary>
        /// The AddOrderMaster.
        /// </summary>
        /// <param name="productDetailModel">The productDetailModel<see cref="ProductDetailModel"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task AddOrderMaster(ProductDetailModel productDetailModel)
        {
            Guid Orderguid = Guid.Empty; //Guid.NewGuid();

            OrderMaster orderMaster = new OrderMaster
            {
                OrderGuid = Orderguid,
                OrderKeyStatus = "Active",
                InsertDate = DateTime.Now,
                OrgId = productDetailModel.ProductBasicModel.OrgId
            };
            // var addOrderMaster = ObjectMapper.Mapper.Map<OrderMaster>(productDetailModel.OrderMasterModel);

            await _ProductDetailRepsitory.AddOrderMaster(orderMaster);
        }

        /// <summary>
        /// The AddToCart.
        /// </summary>
        /// <param name="productDetailModel">The productDetailModel<see cref="ProductDetailModel"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task AddToCart(ProductDetailModel productDetailModel)
        {
            var CartCheck = await _CartRepository.CheckProdInCart((int)productDetailModel.ProductBasicModel.OrgId,productDetailModel.ProductBasicModel.ProductName, _accessor.HttpContext.User.Identity.Name, productDetailModel.SpecId);

            if (CartCheck != null)
            {
                OrderBasic orderBasic1 = new OrderBasic
                {
                    UserName = CartCheck.UserName,
                    OrderGuid = CartCheck.OrderGuid,
                    ProductId = CartCheck.ProductId,
                    Qty = CartCheck.Qty + productDetailModel.OrderBasicModel.Qty
                };
                await _ProductDetailRepsitory.UpdateAddToCart(orderBasic1);
            }
            else
            {
                OrderBasic orderBasic = new OrderBasic();
                orderBasic.ProductId = productDetailModel.ProductBasicModel.ProductId;
                orderBasic.OrderGuid = Guid.Empty;
                orderBasic.Price = productDetailModel.ProductPriceModel.Price;
                orderBasic.DeliveryFees = productDetailModel.ProductPriceModel.DeliveryFees;
                orderBasic.InsertDate = DateTime.Now;
                orderBasic.OrderStatus = "Cart";
                orderBasic.Currencyid = productDetailModel.ProductPriceModel.CurrencyId;
                orderBasic.OrgId = productDetailModel.ProductBasicModel.OrgId;
                orderBasic.Qty = productDetailModel.OrderBasicModel.Qty;
                orderBasic.UserName = _accessor.HttpContext.User.Identity.Name;

                var find = await _ProductDetailRepsitory.check(orderBasic);

                productDetailModel.OrderBasicModel = ObjectMapper.Mapper.Map<OrderBasicModel>(find);

                if (find != null)
                {
                    orderBasic.OrderGuid = find.OrderGuid;
                }
                else
                {
                    Guid Orderguid = Guid.NewGuid();

                    OrderMaster orderMaster = new OrderMaster
                    {
                        OrderGuid = Orderguid,
                        OrderKeyStatus = "Active",
                        InsertDate = DateTime.Now,
                        OrgId = productDetailModel.ProductBasicModel.OrgId
                    };
                    await _ProductDetailRepsitory.AddOrderMaster(orderMaster);
                    orderBasic.OrderGuid = Orderguid;
                }

                await _ProductDetailRepsitory.AddToCart(orderBasic);
            }
            //{
            //   var prodCheck = CartCheck.Where(x => x.UserName == _accessor.HttpContext.User.Identity.Name);

            //    foreach (var setQty in prodCheck) 
            //    {
            //        if(setQty.ProductName == productDetailModel.ProductBasicModel.ProductName)
            //        {
            //          setQty.Qty = setQty.Qty + productDetailModel.OrderBasicModel.Qty;

            //            //  var find = await _ProductDetailRepsitory.check();

            //            //    await _ProductDetailRepsitory.AddToCart();
                       
            //        }
                    
            //    }
                
            //}
                //  await _ProductDetailRepsitory.AddOrderMaster(orderMaster);
                //  productDetailModel.OrderMasterModel = ObjectMapper.Mapper.Map<OrderMasterModel>(orderMaster);
        }

        public async Task<ProductDetailModel> BuyNow(ProductDetailModel productDetailModel)
        {
            Guid Orderguid = Guid.NewGuid();
            OrderMaster orderMaster = new OrderMaster
            {
                OrderGuid = Orderguid,
                OrderKeyStatus = "Active",
                InsertDate = DateTime.Now,
                OrgId = productDetailModel.ProductBasicModel.OrgId
            };
            await _ProductDetailRepsitory.AddOrderMaster(orderMaster);

            OrderBasic orderBasic = new OrderBasic();
            orderBasic.ProductId = productDetailModel.ProductBasicModel.ProductId;
            orderBasic.OrderGuid = Orderguid;
            orderBasic.Price = productDetailModel.ProductPriceModel.Price;
            orderBasic.DeliveryFees = productDetailModel.ProductPriceModel.DeliveryFees;
            orderBasic.InsertDate = DateTime.Now;
            orderBasic.OrderStatus = "Cart";
            orderBasic.Currencyid = productDetailModel.ProductPriceModel.CurrencyId;
            orderBasic.OrgId = productDetailModel.ProductBasicModel.OrgId;
            orderBasic.Qty = productDetailModel.OrderBasicModel.Qty;
            orderBasic.UserName = _accessor.HttpContext.User.Identity.Name;

            await _ProductDetailRepsitory.AddToCart(orderBasic);

            productDetailModel.OrderBasicModel = ObjectMapper.Mapper.Map<OrderBasicModel>(orderBasic);

                return productDetailModel;

            //OrderBasic orderBasic = new OrderBasic();
            //orderBasic.ProductId = productDetailModel.ProductBasicModel.ProductId;
            //orderBasic.OrderGuid = Guid.Empty;
            //orderBasic.Price = productDetailModel.ProductPriceModel.Price;
            //orderBasic.DeliveryFees = productDetailModel.ProductPriceModel.DeliveryFees;
            //orderBasic.InsertDate = DateTime.Now;
            //orderBasic.OrderStatus = "Cart";
            //orderBasic.Currencyid = productDetailModel.ProductPriceModel.CurrencyId;
            //orderBasic.OrgId = productDetailModel.ProductBasicModel.OrgId;
            //orderBasic.Qty = productDetailModel.OrderBasicModel.Qty;
            //orderBasic.UserName = _accessor.HttpContext.User.Identity.Name;

            //var find = await _ProductDetailRepsitory.check(orderBasic);

            //productDetailModel.OrderBasicModel = ObjectMapper.Mapper.Map<OrderBasicModel>(find);

            //if (find != null)
            //{
            //    orderBasic.OrderGuid = find.OrderGuid;
            //}
            //else
            //{
            //    Guid Orderguid = Guid.NewGuid();

            //    OrderMaster orderMaster = new OrderMaster
            //    {
            //        OrderGuid = Orderguid,
            //        OrderKeyStatus = "Active",
            //        InsertDate = DateTime.Now,
            //        OrgId = productDetailModel.ProductBasicModel.OrgId
            //    };
            //    await _ProductDetailRepsitory.AddOrderMaster(orderMaster);
            //    orderBasic.OrderGuid = Orderguid;
            //}

            //await _ProductDetailRepsitory.AddToCart(orderBasic);

        }

        public async Task<List<SP_GetProductDetailsModel>> GetProductVarient(Guid guid, int orgid, int SpecId)
        {
            try
            {
                var GetProductVarients = await _ProductDetailRepsitory.GetProductVarient(guid, orgid, SpecId);
                return ObjectMapper.Mapper.Map<List<SP_GetProductDetailsModel>>(GetProductVarients);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task Addto_Spec_Product(ProductDetailModel productDetailModel)
        {
            if (productDetailModel.SpecId != 0)
            {
                var get_Product_SpecId = await _ProductDetailRepsitory.get_Product_SpecId(productDetailModel.ProductBasicModel.ProductGuid, productDetailModel.ProductBasicModel.OrgId, productDetailModel.SpecId);

                var CartCheck = await _CartRepository.CheckProdInCart((int)productDetailModel.ProductBasicModel.OrgId, productDetailModel.ProductBasicModel.ProductName, _accessor.HttpContext.User.Identity.Name, productDetailModel.SpecId);          

                if (CartCheck != null)
                {
                    if (get_Product_SpecId.ProductSpecificationId == CartCheck.ProductSpecificationId)
                    {
                        OrderBasic orderBasic1 = new OrderBasic
                        {
                            UserName = CartCheck.UserName,
                            OrderGuid = CartCheck.OrderGuid,
                            ProductId = CartCheck.ProductId,
                            Qty = CartCheck.Qty + productDetailModel.OrderBasicModel.Qty
                        };

                        OrderVariation orderVariation = new OrderVariation()
                        {
                            OrderGuid = CartCheck.OrderGuid,
                            ProductSpecificationId = get_Product_SpecId.ProductSpecificationId,
                            OrgId = productDetailModel.ProductBasicModel.OrgId
                        };
                        var OrderVeriant = await _ProductDetailRepsitory.Get_Order_Varient(orderVariation);
                        orderBasic1.OrderVariationId = OrderVeriant.OrderVariationId;

                        await _ProductDetailRepsitory.UpdateAddToCart(orderBasic1);
                    }
                    else
                    {
                        OrderBasic orderBasic = new OrderBasic();
                        orderBasic.ProductId = productDetailModel.ProductBasicModel.ProductId;
                        orderBasic.OrderGuid = Guid.Empty;
                        orderBasic.Price = productDetailModel.ProductPriceModel.Price;
                        orderBasic.DeliveryFees = productDetailModel.ProductPriceModel.DeliveryFees;
                        orderBasic.InsertDate = DateTime.Now;
                        orderBasic.OrderStatus = "Cart";
                        orderBasic.Currencyid = productDetailModel.ProductPriceModel.CurrencyId;
                        orderBasic.OrgId = productDetailModel.ProductBasicModel.OrgId;
                        orderBasic.Qty = productDetailModel.OrderBasicModel.Qty;
                        orderBasic.UserName = _accessor.HttpContext.User.Identity.Name;

                        var find = await _ProductDetailRepsitory.check(orderBasic);

                        productDetailModel.OrderBasicModel = ObjectMapper.Mapper.Map<OrderBasicModel>(find);

                        if (find != null)
                        {
                            orderBasic.OrderGuid = find.OrderGuid;
                        }
                        else
                        {
                            Guid Orderguid = Guid.NewGuid();

                            OrderMaster orderMaster = new OrderMaster
                            {
                                OrderGuid = Orderguid,
                                OrderKeyStatus = "Active",
                                InsertDate = DateTime.Now,
                                OrgId = productDetailModel.ProductBasicModel.OrgId
                            };
                            await _ProductDetailRepsitory.AddOrderMaster(orderMaster);
                            orderBasic.OrderGuid = Orderguid;
                        }


                        if (get_Product_SpecId != null)
                        {
                            OrderVariation orderVariation = new OrderVariation()
                            {
                                OrderGuid = orderBasic.OrderGuid,
                                ProductSpecificationId = get_Product_SpecId.ProductSpecificationId,
                                OrgId = orderBasic.OrgId
                            };
                           var ProductVarient = await _ProductDetailRepsitory.Add_Order_Varient(orderVariation);
                            orderBasic.OrderVariationId = ProductVarient.OrderVariationId;
                        }

                        await _ProductDetailRepsitory.AddToCart(orderBasic);
                    }                 
                }
                else
                {
                    OrderBasic orderBasic = new OrderBasic();
                    orderBasic.ProductId = productDetailModel.ProductBasicModel.ProductId;
                    orderBasic.OrderGuid = Guid.Empty;
                    orderBasic.Price = productDetailModel.ProductPriceModel.Price;
                    orderBasic.DeliveryFees = productDetailModel.ProductPriceModel.DeliveryFees;
                    orderBasic.InsertDate = DateTime.Now;
                    orderBasic.OrderStatus = "Cart";
                    orderBasic.Currencyid = productDetailModel.ProductPriceModel.CurrencyId;
                    orderBasic.OrgId = productDetailModel.ProductBasicModel.OrgId;
                    orderBasic.Qty = productDetailModel.OrderBasicModel.Qty;
                    orderBasic.UserName = _accessor.HttpContext.User.Identity.Name;

                    var find = await _ProductDetailRepsitory.check(orderBasic);

                    productDetailModel.OrderBasicModel = ObjectMapper.Mapper.Map<OrderBasicModel>(find);

                    if (find != null)
                    {
                        orderBasic.OrderGuid = find.OrderGuid;
                    }
                    else
                    {
                        Guid Orderguid = Guid.NewGuid();

                        OrderMaster orderMaster = new OrderMaster
                        {
                            OrderGuid = Orderguid,
                            OrderKeyStatus = "Active",
                            InsertDate = DateTime.Now,
                            OrgId = productDetailModel.ProductBasicModel.OrgId
                        };
                        await _ProductDetailRepsitory.AddOrderMaster(orderMaster);
                        orderBasic.OrderGuid = Orderguid;
                    }


                    if(get_Product_SpecId != null)
                    {
                        OrderVariation orderVariation = new OrderVariation()
                        {
                            OrderGuid = orderBasic.OrderGuid,
                            ProductSpecificationId = get_Product_SpecId.ProductSpecificationId,
                            OrgId = orderBasic.OrgId
                        };
                      var OrderVeriant =  await _ProductDetailRepsitory.Add_Order_Varient(orderVariation);
                        orderBasic.OrderVariationId = orderVariation.OrderVariationId;
                    }

                    await _ProductDetailRepsitory.AddToCart(orderBasic);
                }
            }
            else
            {
                await AddToCart(productDetailModel);
            }
        }
        public async Task<ProductDetailModel> BuyNow_Spec_Product(ProductDetailModel productDetailModel)
        {
            if (productDetailModel.SpecId == 0)
            {
                await BuyNow(productDetailModel);
            }
            else
            {
                Guid Orderguid = Guid.NewGuid();
                OrderMaster orderMaster = new OrderMaster
                {
                    OrderGuid = Orderguid,
                    OrderKeyStatus = "Active",
                    InsertDate = DateTime.Now,
                    OrgId = productDetailModel.ProductBasicModel.OrgId
                };
                await _ProductDetailRepsitory.AddOrderMaster(orderMaster);

                OrderBasic orderBasic = new OrderBasic();
                orderBasic.ProductId = productDetailModel.ProductBasicModel.ProductId;
                orderBasic.OrderGuid = Orderguid;
                orderBasic.Price = productDetailModel.ProductPriceModel.Price;
                orderBasic.DeliveryFees = productDetailModel.ProductPriceModel.DeliveryFees;
                orderBasic.InsertDate = DateTime.Now;
                orderBasic.OrderStatus = "Cart";
                orderBasic.Currencyid = productDetailModel.ProductPriceModel.CurrencyId;
                orderBasic.OrgId = productDetailModel.ProductBasicModel.OrgId;
                orderBasic.Qty = productDetailModel.OrderBasicModel.Qty;
                orderBasic.UserName = _accessor.HttpContext.User.Identity.Name;

                var get_Product_SpecId = await _ProductDetailRepsitory.get_Product_SpecId(productDetailModel.ProductBasicModel.ProductGuid, productDetailModel.ProductBasicModel.OrgId, productDetailModel.SpecId);

                if (get_Product_SpecId != null)
                {
                    OrderVariation orderVariation = new OrderVariation()
                    {
                        OrderGuid = orderBasic.OrderGuid,
                        ProductSpecificationId = get_Product_SpecId.ProductSpecificationId,
                        OrgId = orderBasic.OrgId
                    };
                    var Varient = await _ProductDetailRepsitory.Add_Order_Varient(orderVariation);
                    orderBasic.OrderVariationId = Varient.OrderVariationId;
                }

                await _ProductDetailRepsitory.AddToCart(orderBasic);

                productDetailModel.OrderBasicModel = ObjectMapper.Mapper.Map<OrderBasicModel>(orderBasic);

                return productDetailModel;
            }
            return productDetailModel;
        }
    }
}
