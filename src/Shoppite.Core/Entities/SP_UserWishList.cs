using System;
using System.Collections.Generic;
using System.Text;

namespace Shoppite.Core.Entities
{
    public class SP_UserWishList
    {
        public int WishlistId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
        public Guid? ProductGuid { get; set; }
        public decimal? OldPrice { get; set; }
        public string ProductName { get; set; }
        public string CoverImage { get; set; }
        public string UserName { get; set; }
        public DateTime? InsertDate { get; set; }
        public string Ip { get; set; }
        public int? OrgId { get; set; }
        public string Image { get; set; }
        public string SpecificationName { get; set; }
        public int? SpecificationId { get; set; }
    }
}
