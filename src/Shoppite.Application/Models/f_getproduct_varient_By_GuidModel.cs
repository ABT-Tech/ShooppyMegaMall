using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Application.Models
{
    public partial class f_getproduct_varient_By_GuidModel
    {

        public string ProductName { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
        public string SpecificationName { get; set; }
        public int? AttributeId { get; set; }
        public string SubSpecificationName { get; set;  }
        public int? SubAttributeId { get; set; }

    }
}
