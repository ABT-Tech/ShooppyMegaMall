using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShooppyMegaMall.Core.Entities
{
    public partial class F_Topcat_Result
    {
        public string urlpath { get; set; }
        [Key]
        public Nullable<int> category_id { get; set; }
        public Nullable<int> parent_category_id { get; set; }
        public string category_name { get; set; }
    }
}
