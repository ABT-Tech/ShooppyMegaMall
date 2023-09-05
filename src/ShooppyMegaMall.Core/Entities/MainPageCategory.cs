using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Core.Entities
{
    public partial class MainPageCategory
    {
        public int MainPageCategoryId { get; set; }
        public string MainPageCategory1 { get; set; }
        public string Status { get; set; }
        public int? OrgId { get; set; }
    }
}
