﻿namespace ShooppyMegaMall.UI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Razorpay.Api;
    using ShooppyMegaMall.Application.Models;
    using ShooppyMegaMall.UI.Extensions;
    using ShooppyMegaMall.UI.Helpers;
    using ShooppyMegaMall.UI.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    
    public class CartController : Controller
    {
        /// <summary>
        /// Defines the _cartPageService.
        /// </summary>
        private readonly ICartPageServices _cartPageService;

        /// <summary>
        /// Defines the _commonHelper.
        /// </summary>
        private readonly ICommonHelper _commonHelper;

        /// <summary>
        /// Defines the _commonHelper.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartController"/> class.
        /// </summary>
        /// <param name="cartPageServices">The cartPageServices<see cref="ICartPageServices"/>.</param>
        /// <param name="commonHelper">The commonHelper<see cref="ICommonHelper"/>.</param>
        public CartController(ICartPageServices cartPageServices, ICommonHelper commonHelper, IConfiguration configuration)
        {
            _cartPageService = cartPageServices ?? throw new ArgumentNullException(nameof(cartPageServices));
            _commonHelper = commonHelper;
            _configuration = configuration;
        }

        /// <summary>
        /// The Cart.
        /// </summary>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [ShooppyMegaMall.UI.Extensions.Authorize]
        public async Task<IActionResult> Cart()
        {
            int orgid = _commonHelper.GetOrgID(HttpContext);
            var cartlist = await _cartPageService.OrderBasic(orgid);
            foreach (var swap in cartlist.F_Getproduct_CartDetails_By_Orgids)
            {
                if (swap.Qty > swap.BasicQty)
                {
                    swap.Qty = swap.BasicQty;
                }
            }

            return View(cartlist);
        }

        /// <summary>
        /// The DeleteProduct.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [ShooppyMegaMall.UI.Extensions.Authorize]
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            _cartPageService.DeleteAysnc(id);
            return RedirectToAction("Cart");
        }

        /// <summary>
        /// The AddToCheck.
        /// </summary>
        /// <param name="checkOut">The checkOut<see cref="CheckOutModel"/>.</param>
        /// <returns>The <see cref="Task{ActionResult}"/>.</returns>
        [ShooppyMegaMall.UI.Extensions.Authorize]
        [HttpPost]
        public async Task<ActionResult> AddToCheck([FromBody] CheckOutModel checkOut)
        {
            await _cartPageService.UpdateOrderQty(checkOut);

            return Json(checkOut);
        }

        /// <summary>
        /// The CheckOut.
        /// </summary>
        /// <param name="orderid">The orderid<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{ActionResult}"/>.</returns>
        [ShooppyMegaMall.UI.Extensions.Authorize]
        public async Task<ActionResult> CheckOut(Guid orderid)
        {
            try
            {
                decimal totalOrderPrice = 0;
                int Order_Id = 0;
                var order = await _cartPageService.CheckOrder(orderid);
                var merchantDetails = _commonHelper.GetMerchantDetails(HttpContext);
                order.IsPaytm = false;
                if (merchantDetails != null)
                {
                    order.IsPaytm = true;
                }
                foreach(var total in order.OrderBasicModels)
                {
                     totalOrderPrice += (decimal)total.Price;
                     Order_Id = (int)total.OrderId;
                }

                ViewBag.OrderPrice = totalOrderPrice;
                ViewBag.Order_Id = Order_Id;
                return View(order);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        /// <summary>
        /// The OrderSuccess.
        /// </summary>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult OrderSuccess()
        {   
            return View();
        }

        /// <summary>
        /// The OrderSuccess.
        /// </summary>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult OrderPaymentFail()
        {
            return View();
        }

        /// <summary>
        /// The SaveAddress.
        /// </summary>
        /// <param name="Model">The Model<see cref="CartModel"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost]
        [ShooppyMegaMall.UI.Extensions.Authorize]
        public async Task<IActionResult> SaveAddress(CartModel Model)
        {
            int orgid = _commonHelper.GetOrgID(HttpContext);
            Model.OrderShippingModel.OrgId = orgid;
            await _cartPageService.SaveAddress(Model);

            return RedirectToAction("OrderSuccess");
        }

        [HttpPost]
        [ShooppyMegaMall.UI.Extensions.Authorize]
        public async Task<IActionResult> MakePaymentRequest(CartModel Model)
        {
            int orgid = _commonHelper.GetOrgID(HttpContext);
            Model.OrderShippingModel.OrgId = orgid;
            await _cartPageService.SaveAddress(Model);
            if (Model.IsPaytmClicked)
            {
                var order = await _cartPageService.CheckOrder((Guid)Model.OrderBasicModel.OrderGuid);
                var merchantDetails = _commonHelper.GetMerchantDetails(HttpContext);
                var strProductMapping = string.Empty;
                decimal? TotalOrderCharge = 0;
                decimal? TotalProductCharges = 0;
                var IsTestEnable = _configuration.GetSection("OnePeSettings")["IsTest"].ToString();
                ViewBag.AggregatorRedirectionLink = _configuration.GetSection("OnePeSettings")["URL"];
                foreach (var orderDetails in order.OrderBasicModels)
                {
                    TotalProductCharges = orderDetails.Price + orderDetails.DeliveryFees;
                    if (string.IsNullOrEmpty(strProductMapping))
                        strProductMapping += orderDetails.ProductId + "~" + TotalProductCharges;
                    else
                        strProductMapping += "|" + orderDetails.ProductId + "~" + TotalProductCharges;
                    TotalOrderCharge = TotalOrderCharge + TotalProductCharges;
                }
                using (HttpClient client = new HttpClient())
                {
                    MerchantParams merchantParams = new MerchantParams();
                    merchantParams.merchantId = merchantDetails.AggregatorMerchantId;
                    merchantParams.apiKey = merchantDetails.AggregatorMerchantApiKey;
                    merchantParams.txnId = order.OrderBasicModel.OrderGuid.ToString();
                    merchantParams.amount = IsTestEnable == "1" ? "10.00" : TotalOrderCharge.ToString();
                    merchantParams.dateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    merchantParams.custMail = Model.OrderShippingModel.Email;
                    merchantParams.custMobile = Model.OrderShippingModel.Phone;
                    merchantParams.udf1 = Model.OrderShippingModel.Address;
                    merchantParams.udf2 = Model.OrderShippingModel.Address;
                    merchantParams.returnURL = merchantDetails.AggregatorCallbackURL + "Cart/PaymentResponse";
                    merchantParams.isMultiSettlement = "0";
                    merchantParams.productId = "DEFAULT";
                    merchantParams.channelId = "0";
                    merchantParams.txnType = "DIRECT";
                    merchantParams.Rid = merchantDetails.AggregatorRID.ToString();
                    var objMerchantParams = JsonConvert.SerializeObject(merchantParams);
                    string encryptedParams = EncryptPaymentRequest(merchantDetails.AggregatorMerchantId, merchantDetails.AggregatorMerchantApiKey, objMerchantParams);
                    ViewBag.merchantId = merchantDetails.AggregatorMerchantId;
                    ViewBag.reqData = encryptedParams;
                }
                return View();
            }
            else
            {
                await _cartPageService.UpdateOrder((Guid)Model.OrderBasicModel.OrderGuid);
                var vendorContactdetails = await _cartPageService.GetVendorContactDetails((Guid)Model.OrderBasicModel.OrderGuid);

                var IsWhatsappEnable = _configuration.GetSection("WhatsAppSettings")["IsEnable"].ToString();
                if (IsWhatsappEnable == "1")
                {
                    _commonHelper.LogError("Call WhatsApp from MakePaymentRequest - orderID : " + vendorContactdetails.Item1 + ", mobileNumber : " + vendorContactdetails.Item2 + ", orgname : " + vendorContactdetails.Item3 + ", Template : order_notify_to_vendor_templateid ");
                    await _commonHelper.SendWhatsAppMesage(vendorContactdetails.Item1, vendorContactdetails.Item2, vendorContactdetails.Item3, "order_notify_to_vendor_templateid");
                }
                return RedirectToAction("OrderSuccess");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PaymentResponse()
        {
            var response = HttpContext.Request.Form["respData"];
            var merchantDetails = _commonHelper.GetMerchantDetails(HttpContext);   
            string merchantEncryptionKey = merchantDetails.AggregatorMerchantApiKey.Substring(0, 16);
            var merchantResponse = _commonHelper.DecryptAES256_V3(response.ToString(), merchantDetails.AggregatorMerchantApiKey, merchantEncryptionKey);
            var objmerchangeResponse = JsonConvert.DeserializeObject<MerchantResponse>(merchantResponse);
            if(objmerchangeResponse.trans_status =="Ok")
            {
                await _cartPageService.UpdateOrder(new Guid(objmerchangeResponse.txn_id));
                await _cartPageService.GetVendorContactDetails(new Guid(objmerchangeResponse.txn_id));
                var vendorContactdetails = await _cartPageService.GetVendorContactDetails(new Guid(objmerchangeResponse.txn_id));

                var IsWhatsappEnable = _configuration.GetSection("WhatsAppSettings")["IsEnable"].ToString();
                if(IsWhatsappEnable == "1")
                {
                    _commonHelper.LogError("Call WhatsApp from PaymentResponse - orderID : " + vendorContactdetails.Item1 + ", mobileNumber : " + vendorContactdetails.Item2 + ", orgname : " + vendorContactdetails.Item3 + ", Template : order_notify_to_vendor_templateid ");
                    await _commonHelper.SendWhatsAppMesage(vendorContactdetails.Item1, vendorContactdetails.Item2, vendorContactdetails.Item3, "order_notify_to_vendor_templateid");
                }

                return RedirectToAction("OrderSuccess");
            }
            else
            {
                await _cartPageService.CancelOrder(new Guid(objmerchangeResponse.txn_id));
                return RedirectToAction("OrderPaymentFail");
            }
        }

        public string EncryptPaymentRequest(string merchantId,string key,string merchantParamsJson)
        {
            String encryptedText = string.Empty;
            try
            {
                string original = merchantParamsJson; 
                string merchantEncryptionKey = key.Substring(0, 16);
                encryptedText = _commonHelper.EncryptAES256_V3(merchantParamsJson, key, merchantEncryptionKey);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }

            return encryptedText;
        }

        public async Task<Order> razorPayMakeOrder(CartModel cartModel)
        {
            var KeyId = _configuration.GetSection("RazorPaySettings")["key_id"].ToString();
            var KeySecret = _configuration.GetSection("RazorPaySettings")["key_secret"].ToString();

            RazorpayClient client = new RazorpayClient(KeyId, KeySecret);

            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", cartModel.OrderPrice); // amount in the smallest currency unit
            options.Add("receipt", "order_receipt_" + cartModel.Order_Id);
            options.Add("currency", "INR");
            Order order = client.Order.Create(options);
            return order;
        }

        public async Task<IActionResult> razorPaymentGetway(CartModel cartModel)
        {
            try
            {
                var getOrderId = await razorPayMakeOrder(cartModel);

                string Order_Id = getOrderId.Attributes["id"].Value;
                ViewBag.OrderId = Order_Id;
                return View(getOrderId);
            }
            catch (Exception e)
            {
                throw e;
            }         
        }       
    }
}
