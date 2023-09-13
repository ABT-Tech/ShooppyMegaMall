using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Application.Models
{ 
    public class CartModel
    {
        public  List<OrderBasicModel> OrderBasicModels { get; set; }
        public  List<f_getproduct_CartDetails_By_OrgidModel> F_Getproduct_CartDetails_By_Orgids { get; set; }
        public OrderShippingModel OrderShippingModel { get; set; }
        public OrderBasicModel OrderBasicModel { get; set; }
        public UsersProfileModal UsersProfileModal { get; set; }
        public bool IsPaytm { get; set; }
        public bool IsPaytmClicked { get; set; }
        public decimal? OrderPrice { get; set; }
        public int? Order_Id { get; set; }
    }
}
