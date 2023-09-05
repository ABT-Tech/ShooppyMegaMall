﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShooppyMegaMall.Application.Models
{
    public partial class MessagesModel
    {
        public int MesageId { get; set; }
        public Guid? ChatId { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public DateTime? Senddate { get; set; }
        public DateTime? Recieveddate { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Attachment { get; set; }
        public int? SessionBookingId { get; set; }
        public int? OrgId { get; set; }
        public List<MessagesModel> MessagesModelList { get; set; }
    }
}