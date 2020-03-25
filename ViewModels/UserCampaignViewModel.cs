using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDFrontEnd.Models;

namespace DnDFrontEnd.ViewModels
{
    public class UserCampaignViewModel
    {
        public Users Users { get; set; }
        public UsersBelongToCampaign UsersBelongToCampaign { get; set; }
        public Campaign Campaign { get; set; }

    }
}
