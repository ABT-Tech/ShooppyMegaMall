using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class Status
    {
        public int StatusId { get; set; }
        public string Status1 { get; set; }
        public string Urlpath { get; set; }
        public bool? ShowOnFront { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UserName { get; set; }
        public string CssClass { get; set; }
        public int? OrgId { get; set; }
    }
}
