using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Core.Entities
{
  public partial class f_getproduct_OrderDetails_By_Orgid
    {
        public int? ProductId { get; set; }
        public Guid? OrderGuid { get; set; }
        public string ProductName { get; set; }
        public int? ProfileId { get; set; }
        public string UserName { get; set; }
        public Guid? ProductGuid { get; set; }
        public string CoverImage { get; set; }
        public decimal? Price { get; set; }
        public int? Qty { get; set; }
        public int? BasicQty { get; set; }
        public decimal? DeliveryFees { get; set; }
    }
}
