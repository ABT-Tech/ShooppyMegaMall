using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Application.Models
{
    public class ProductImagesModel
    {
        public int ProductImagesId { get; set; }
        public Guid? ProductGuid { get; set; }
        public string Image { get; set; }
        public string AltText { get; set; }
        public string Title { get; set; }
        public int? Displayorder { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UserName { get; set; }
        public int? OrgId { get; set; }
    }
}
