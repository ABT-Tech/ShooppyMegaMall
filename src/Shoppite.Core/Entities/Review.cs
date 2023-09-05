using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int? Star { get; set; }
        public string Comments { get; set; }
        public int? TransactionId { get; set; }
        public string Module { get; set; }
        public string UserName { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? OrgId { get; set; }
    }
}
