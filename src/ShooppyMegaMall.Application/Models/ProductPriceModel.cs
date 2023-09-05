using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Application.Models
{
    public class ProductPriceModel
    {
        [Key]
        public int ProductPriceId { get; set; }
        public Guid? ProductGuid { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; }
        public bool DisableBuyButton { get; set; }
        public bool TaxExempt { get; set; }
        public decimal? DeliveryFees { get; set; }
        public int? OrgId { get; set; }
    }
}
