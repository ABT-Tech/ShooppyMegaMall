using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Core.Entities
{
    public partial class WebsiteSetup
    {
        public int WebsiteSetupId { get; set; }
        public string ItemKey { get; set; }
        public string ItemName { get; set; }
        public decimal? ItemValue { get; set; }
        public string ItemDescription { get; set; }
        public bool? IsActive { get; set; }
        public string Type { get; set; }
        public string DeductionType { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UserName { get; set; }
        public int? OrgId { get; set; }
    }
}
