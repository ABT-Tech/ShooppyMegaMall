using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class WebsiteSetupScript
    {
        public int Scriptid { get; set; }
        public string Title { get; set; }
        public string Scriptname { get; set; }
        public string Type { get; set; }
        public int? OrgId { get; set; }
    }
}
