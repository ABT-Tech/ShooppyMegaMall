using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShooppyMegaMall.Application.Models
{
    public class RegisterModel
    {
        public RegisterDetails Regdata { get; set; }
    }
    public class RegisterDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
