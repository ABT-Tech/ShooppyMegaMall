using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Core.Entities
{
    
    public partial class Country
    {
        public int Countryid { get; set; }
        public string CountryName { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public DateTime? InsertDate { get; set; }
        public string InsertBy { get; set; }
    }
}
