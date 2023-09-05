using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class f_getproduct_specification_By_Guid
    {

        public decimal Price { get; set; }
        public string SpecificationName { get; set; }
        public string SubSpecificationName { get; set;  }
        public int? AttributeId { get; set; }
        public int? SubAttributeId { get; set; }

    }
}
