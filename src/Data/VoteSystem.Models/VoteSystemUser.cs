using System;
using System.Collections.Generic;

namespace VoteSystem.Data.Entities
{
    public class VoteSystemUser
    {
        public VoteSystemUser()
        {
            this.Participants = new HashSet<Participant>();
        }

        public Guid Id { get; set; }
     
        public string Email { get; set; }

        public ICollection<Participant> Participants { get; set; }
    }
}
