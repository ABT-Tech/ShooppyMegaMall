using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Core.Entities
{
    public partial class EmailSetup
    {
        public int EmailSettingId { get; set; }
        public string EmailFrom { get; set; }
        public string Password { get; set; }
        public int? Smtpport { get; set; }
        public string Host { get; set; }
        public string Bcc { get; set; }
        public string Type { get; set; }
        public int? OrgId { get; set; }
    }
}
