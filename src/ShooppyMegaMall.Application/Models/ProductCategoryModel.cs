using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Application.Models
{
    public class ProductCategoryModel
    {
        public int ProductCategoryId { get; set; }
        public Guid? ProductGuid { get; set; }
        public int? CategoryId { get; set; }
        public int? MainCatId { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UserName { get; set; }
        public int? OrgId { get; set; }
    }
}
