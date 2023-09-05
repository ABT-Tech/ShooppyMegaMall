using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Application.Models
{
    public class ProductSpecificationModel
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
