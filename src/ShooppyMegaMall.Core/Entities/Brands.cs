using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Core.Entities
{ 
    public partial class Brands
    {
        public int BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }
        public string BrandImage { get; set; }
        public string BrandUrlpath { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsPublished { get; set; }
        public string UserName { get; set; }
        public int? OrgId { get; set; }
    }
}
