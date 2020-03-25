using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace DnDFrontEnd.ViewModels
{
    public class DmSheetViewModel
    {
        public Users Users { get; set; }
        public Campaign Campaign { get; set; }
        public UsersBelongToCampaign UsersBelongToCampaign { get; set; }
    }
}
