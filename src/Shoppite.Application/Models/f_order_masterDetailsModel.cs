using System;
using System.Collections.Generic;
using System.Text;

namespace Shoppite.Application.Models
{
   public class f_order_masterDetailsModel
    {
        public int OrderMasterId { get; set; }
        public string orderdate { get; set; }
        public int UserId { get; set; }
        //  public Nullable<decimal> TotalPrice { get; set; }
        public int? OrgId { get; set; }
        public decimal totalprice { get; set; }
        public string OrderStatus { get; set; }
    }
}
