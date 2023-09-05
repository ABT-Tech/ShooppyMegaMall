using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class ProductSpecification
    {
        public int ProductSpecificationId { get; set; }
        public Guid? ProductGuid { get; set; }
        public int? SpecificationId { get; set; }
        public int? SubSpecificationId { get; set; }
        public string ControlType { get; set; }
        public decimal? Price { get; set; }
        public string? Image { get; set; }
        public DateTime? Insertdate { get; set; }
        public string UserName { get; set; }
        public int? OrgId { get; set; }
        public int? Quantity { get; set; }
        public bool IsDefault { get; set; }
    }
}
