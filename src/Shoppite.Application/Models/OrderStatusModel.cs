using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Application.Models
{
    public class OrderStatusModel
    {
        public int OrderStatusId { get; set; }
        public int? OrderId { get; set; }
        public string OrderStatus1 { get; set; }
        public DateTime? StatusDate { get; set; }
        public string Remarks { get; set; }
        public DateTime? Insertby { get; set; }
        public int? OrgId { get; set; }
    }
}
