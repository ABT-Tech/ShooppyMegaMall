using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class DonationMaster
    {
        public int RequestFundId { get; set; }
        public Guid? RequestFundGuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Administrativefee { get; set; }
        public bool? IsActive { get; set; }
        public string UserName { get; set; }
        public DateTime? InsertDate { get; set; }
        public string PaypalId { get; set; }
        public bool? AdminStatus { get; set; }
        public string AdminRemarks { get; set; }
        public int? OrgId { get; set; }
    }
}
