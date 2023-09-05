﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Core.Entities
{
    public partial class CustomerWishlist
    {
        public int WishlistId { get; set; }
        public int? ProductId { get; set; }
        public string UserName { get; set; }
        public DateTime? InsertDate { get; set; }
        public string Ip { get; set; }
        public int? OrgId { get; set; }
        public int? ProductSpecificationId { get; set; }

    }
}