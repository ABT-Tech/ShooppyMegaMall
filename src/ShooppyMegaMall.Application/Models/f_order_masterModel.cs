using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Application.Models
{
    public class f_order_masterModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Guid ProductGUID { get; set; }
        public Nullable<System.Guid> OrderGUID { get; set; }
        public Nullable<decimal> totalPrice { get; set; }
        public string orderdate { get; set; }
        public string ProductName { get; set; }
        public string CoverImage { get; set; }
        public int Qty { get; set; }
        public int OrgId { get; set; }
        public string UserName { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public string LastOrderStatus { get; set; }
        public string OrderStatus { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
     //   public string Phone { get; set; }
        public string Email { get; set; }
        public string Contactnumber { get; set; }
        public string PaymentMode { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<decimal> deliveryfees { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
