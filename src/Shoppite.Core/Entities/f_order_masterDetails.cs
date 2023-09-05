using System;
using System.Collections.Generic;
using System.Text;

namespace Shoppite.Core.Entities
{
    public class f_order_masterDetails
    {
        public int OrderMasterId { get; set; }   
        public string orderdate { get; set; }
        public string UserName { get; set; }
        public int? OrgId { get; set; }
        public string OrderStatus { get; set; }
        public decimal totalprice { get; set; }

    }
}
