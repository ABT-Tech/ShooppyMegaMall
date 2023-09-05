using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Core.Entities
{
    public partial class OrganizationAggregatorControl
    {
        public int Id { get; set; }
        public string AggregatorMerchantId { get; set; }
        public string AggregatorMerchantApiKey { get; set; }
        public string AggregatorRID { get; set; }
        public string AggregatorCallbackURL { get; set; }
        public int OrgId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
