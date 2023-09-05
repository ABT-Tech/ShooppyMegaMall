using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ShooppyMegaMall.Core.Entities
{
    
    public partial class SP_Status_HasProducts_Result
    {
        public string Status { get; set; }
        public string CssClass { get; set; }
        public int StatusId { get; set; }
        public bool ShowOnFront { get; set; }
        public string URLPath { get; set; }
    }
}
