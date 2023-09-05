using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Models
{
    public class GetSpecModel
    {
        public string Guid { get; set; }
        public string SpecId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string Orgid { get; set; }
        public string Image { get; set; }
        public string name { get; set; }
        public bool? Is_In_WishList { get; set; }
    }
}
