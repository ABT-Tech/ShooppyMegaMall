﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class AttributesSetup
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UserName { get; set; }
        public int? ProfileId { get; set; }
        public int? OrgId { get; set; }
    }
}
