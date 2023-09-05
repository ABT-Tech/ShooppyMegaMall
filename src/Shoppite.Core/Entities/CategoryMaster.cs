using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class CategoryMaster
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Urlpath { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Banner { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsShowHomePage { get; set; }
        public bool? IsIncludeMenu { get; set; }
        public string SeoPageName { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string UserName { get; set; }
        public int? DisplayOrder { get; set; }
        public int? OrgId { get; set; }
    }
}
