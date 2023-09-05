using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Application.Models
{
    public partial class UsersModal
    {
        public int UserId { get; set; }

        //[Required]
        //[RegularExpression("^[a-zA-Z]*$", ErrorMessage = "only alphabet")]
        public string Username { get; set; }


        //   [StringLength(15, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 15 char")]
        // [DataType(DataType.Password)]
        //    [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be  between 8 to 15 characters and contain One UpperCase,One LowerCase and One number")]
       // [Required(ErrorMessage = "Password is required" )]
        public string Password { get; set; }
        public string Exist_Password { get; set; }
        [Required]
        public string ConfPassword { get; set; }
        public string Email { get; set; }
        public string Exist_Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public Guid Guid { get; set; }
        public int? OrgId { get; set; }
       public LogoModel? LogoModel { get; set; } 
    }
}
