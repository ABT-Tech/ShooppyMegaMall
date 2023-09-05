using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class AdsPlacement
    {
        public int AdsPlacementId { get; set; }
        public string PlacementName { get; set; }
        public string Description { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string Status { get; set; }
        public int? OrgId { get; set; }
    }
}
