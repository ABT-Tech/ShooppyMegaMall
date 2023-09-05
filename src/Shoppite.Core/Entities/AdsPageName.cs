using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class AdsPageName
    {
        public int AdsPageId { get; set; }
        public int? AdsPlacementId { get; set; }
        public string PageName { get; set; }
        public string Status { get; set; }
        public int? OrgId { get; set; }
    }
}
