using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Core.Entities
{
    public partial class PageCategory
    {
        public int PageCategoryId { get; set; }
        public int? MainPageCategoryId { get; set; }
        public string Type { get; set; }
        public string PageCategory1 { get; set; }
        public string Status { get; set; }
        public bool? IsUrl { get; set; }
        public string Url { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Sortnumber { get; set; }
        public int? OrgId { get; set; }
    }
}
