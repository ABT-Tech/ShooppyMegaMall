using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Application.Models
{
    public class ProductRecentlyViewedModel
    {
        public int RecentlyViewId { get; set; }
        public int? ProductId { get; set; }
        public string Ip { get; set; }
        public DateTime? Insertdate { get; set; }
        public int? OrgId { get; set; }
    }
}
