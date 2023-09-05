using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class OrderDisbursement
    {
        public int OrderEarningId { get; set; }
        public int? OrderId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DisburseDate { get; set; }
        public string DisbursementMode { get; set; }
        public string DisbursementId { get; set; }
        public string InsertBy { get; set; }
        public int? OrgId { get; set; }
    }
}
