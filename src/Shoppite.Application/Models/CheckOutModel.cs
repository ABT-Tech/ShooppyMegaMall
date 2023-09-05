using System;
using System.Collections.Generic;
using System.Text;

namespace Shoppite.Application.Models
{
   public class CheckOutModel
    {
       public List<CheckOutOrder> ar { get; set; }
    }

    public class CheckOutOrder
    {
        public string Guid { get; set; }
        //public string Image { get; set; }
        //public string ProductName { get; set; }
        //public string Price { get; set; }
        public string Qty { get; set; }
        public string ProductId { get; set; }
    }

}
