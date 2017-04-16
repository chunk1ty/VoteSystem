using System;

namespace VoteSystem.Data.Entities
{
    public class Participant
    {
        public int Id { get; set; }

        public bool IsVoted { get; set; }

        public Guid VoteSystemUserId { get; set; }
        public virtual VoteSystemUser VoteSystemUser { get; set; }

        public int VoteSystemId { get; set; }
        public virtual VoteSystem VoteSystem { get; set; }
    }
}
