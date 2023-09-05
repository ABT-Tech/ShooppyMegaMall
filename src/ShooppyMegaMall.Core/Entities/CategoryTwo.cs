using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Core.Entities
{
    public partial class CategoryTwo
    {
        public int CategoryTwoId { get; set; }
        public int? CategoryOneId { get; set; }
        public string CategoryTwoName { get; set; }
        public string UrlPath { get; set; }
        public string Icon { get; set; }
        public string Banner { get; set; }
        public string Description { get; set; }
        public string IsFeatured { get; set; }
        public string Status { get; set; }
        public int? OrgId { get; set; }
    }
}
