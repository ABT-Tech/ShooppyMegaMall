using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Core.Entities
{
    public class SP_GetSpecificationData_AttributName
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public int SpecificationId { get; set; }
        public string SpecificationName { get; set; }
        public int? OrgId { get; set; }
    }
}
