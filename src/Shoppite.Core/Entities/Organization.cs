using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    public partial class Organization
    {
        public int Id { get; set; }
        public string OrgName { get; set; }
        public string OrgLogo { get; set; }
        public string VenderName { get; set; }
        public string VEmail { get; set; }
        public string VPhone { get; set; }
        public string VMobile { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? Pincode { get; set; }
        public string OrgAddress { get; set; }
        public string OrgDescription { get; set; }
        public string VBankName { get; set; }
        public string VAccountNumber { get; set; }
        public string VIfscCode { get; set; }
        public string VBankBranchName { get; set; }
        public string VUpiId { get; set; }
        public string VIdProof { get; set; }
        public string AboutUs { get; set; }
    }
}
