using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class DonationReceived
    {
        public int DonationReceivedId { get; set; }
        public Guid? RequestFundGuid { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AdministrativeFeesPer { get; set; }
        public decimal? AdministrativeAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaypalId { get; set; }
        public int? OrgId { get; set; }
    }
}
