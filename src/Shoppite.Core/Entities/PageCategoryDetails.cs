using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class PageCategoryDetails
    {
        public int PageCategoryDetailId { get; set; }
        public int? PageCategoryId { get; set; }
        public string PageCategoryDescriptoin { get; set; }
        public string Status { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? OrgId { get; set; }
    }
}
