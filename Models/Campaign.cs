using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            PlayerCharacter = new HashSet<PlayerCharacter>();
            UsersBelongToCampaign = new HashSet<UsersBelongToCampaign>();
        }

        public int CampaignId { get; set; }
        public string CampaignName { get; set; }

        public virtual ICollection<PlayerCharacter> PlayerCharacter { get; set; }
        public virtual ICollection<UsersBelongToCampaign> UsersBelongToCampaign { get; set; }

    }
}
