using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Application.Models
{
    public class SP_GetProductSpecificationsModel
    {
        public string SpecificationNames { get; set; }
        public int SpecificationIds { get; set; }
        public int IsSpecificationExist { get; set; }
        public bool IsDefault { get; set; }
        public int ProductSpecificationId { get; set; }
    }
}
