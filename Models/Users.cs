using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Users
    {
        public Users()
        {
            PlayerCharacter = new HashSet<PlayerCharacter>();
            UsersBelongToCampaign = new HashSet<UsersBelongToCampaign>();
        }

        public int UsersId { get; set; }
        public string UserName { get; set; }
        public string UsersEmail { get; set; }

        public virtual ICollection<PlayerCharacter> PlayerCharacter { get; set; }
        public virtual ICollection<UsersBelongToCampaign> UsersBelongToCampaign { get; set; }
    }
}
