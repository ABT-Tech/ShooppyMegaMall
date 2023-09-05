using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Core.Entities
{
    public partial class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
        public int? OrgId { get; set; }
    }
}
