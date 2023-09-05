using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Core.Entities
{
    public partial class SP_GetProductSpecifications
    {
        public string SpecificationNames { get; set; }
        public int SpecificationIds { get; set; }
        public int IsSpecificationExist { get; set; }
        public bool IsDefault { get; set; }
        public int ProductSpecificationId { get; set; }
    }
}
