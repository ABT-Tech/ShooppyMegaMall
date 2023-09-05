using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Application.Models
{
    public class f_Get_MyAccount_Data_Model
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int OrgId { get; set; }
        public int ProfileId { get; set; }
        public string UserName { get; set; }
        public string CoverImage { get; set; }       
        public string ContactNumber { get; set; }    
        public string Address { get; set; }
    }
}
