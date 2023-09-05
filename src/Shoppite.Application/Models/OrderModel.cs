using System;
using System.Collections.Generic;
using System.Text;

namespace Shoppite.Application.Models
{
    public class OrderModel
    {
        public OrderBasicModel OrderBasicModel { get; set; }
        public OrderShippingModel OrderShippingModel { get; set; }
        public OrderStatusModel OrderStatusModel { get; set; }
        public UsersProfileModal UsersProfileModel { get; set; }
        public List<ProductBasicModel> ProductBasicModel { get; set; }
        public List<f_order_masterModel> productDetails { get; set; }
        public f_order_masterModel f_Order_MasterModel { get; set; }
        public f_order_masterDetailsModel ordermasterDetails { get; set; }
        public List<f_order_masterDetailsModel> MyOrderDetails { get; set; }
        public string UserName { get; set; }
    }
}
