using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShooppyMegaMall.Application.Models
{
    public class LoginCheckModel
    {
        public Loginsubmodel datal { get; set; }
    }
    public class Loginsubmodel
    {
        [Required]
        public string userid { get; set; }
        [Required]
        public string password { get; set; }
    }
}
