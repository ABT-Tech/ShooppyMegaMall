using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Application.Models
{
    public class OrderShippingModel
    {
        public int ShippingId { get; set; }
        public Guid? OrderGuid { get; set; }
        [Required]
        [RegularExpression("[A-Za-z]", ErrorMessage ="Only alphabets allowed")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("[A-Za-z]", ErrorMessage = "Only alphabets allowed")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9'\.\-\s\,]", ErrorMessage = "Please enter valid Adress")]
        public string Address { get; set; }
        [Required]
        [RegularExpression("[A-Za-z0-9 - ]", ErrorMessage = "Please enter valid Adress")]
        public string Street { get; set; }
        [Required]
        [RegularExpression("[A-Za-z]", ErrorMessage = "Please enter a valid city name")]
        public string City { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "only numbers")]
        public string Zipcode { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "only numbers allowed")]
        public string Phone { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UserName { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Enter a valid mail address")]
        public string Email { get; set; }
        public string Contactnumber { get; set; }
        public int? OrgId { get; set; }
    }
}
