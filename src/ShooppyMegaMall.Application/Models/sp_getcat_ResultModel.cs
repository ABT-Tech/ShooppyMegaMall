using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Application.Models
{
    public class sp_getcat_ResultModel
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> PARENT_NAMEID { get; set; }
        public Nullable<int> HLevel { get; set; }
        public string NAME { get; set; }
        public string Displayname { get; set; }
        public string catnames { get; set; }
        public string Icons { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsShowHomePage { get; set; }
        public bool? IsIncludeMenu { get; set; }
    }
}
