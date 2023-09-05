using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Core.Entities
{
    
    public partial class Currency
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UserName { get; set; }
        public bool? Isbase { get; set; }
    }
}
