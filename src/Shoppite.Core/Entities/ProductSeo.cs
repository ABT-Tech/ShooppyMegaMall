using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class ProductSeo
    {
        public int Seoid { get; set; }
        public Guid? ProductGuid { get; set; }
        public string SeoPageName { get; set; }
        public string SeoMetaTitle { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoMetadescription { get; set; }
        public int? OrgId { get; set; }
    }
}
