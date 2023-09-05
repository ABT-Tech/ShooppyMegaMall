using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class OrderBasic
    {
        public int OrderId { get; set; }
        public Guid? OrderGuid { get; set; }
        public int? ProductId { get; set; }
        public int? Qty { get; set; }
        public decimal? Price { get; set; }
        public decimal? Tax { get; set; }
        public decimal? DeliveryFees { get; set; }
        public decimal? Vat { get; set; }
        public string Comments { get; set; }
        public string UserName { get; set; }
        public DateTime? InsertDate { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentMode { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string ReferenceId { get; set; }
        public decimal? Commission { get; set; }
        public decimal? Donation { get; set; }
        public int?  OrderVariationId { get; set; }
        public string OrderVariation { get; set; }
        public int? Currencyid { get; set; }
        public string LastOrderStatus { get; set; }
        public int? OrgId { get; set; }
    }
}
