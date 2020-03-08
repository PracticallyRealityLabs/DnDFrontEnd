using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class UsersBelongToCampaign
    {
        public int? UsersBelongToCampaignid { get; set; }
        public int? CampaignId { get; set; }
        public int? UserId { get; set; }
        public bool? Role { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Users User { get; set; }
    }
}
