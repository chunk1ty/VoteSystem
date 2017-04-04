using System.Collections.Generic;

namespace VoteSystem.Data.Entities
{
    public class Participant
    {
        public int Id { get; set; }

        public bool IsVoted { get; set; }

        public string VoteSystemUserId { get; set; }

        public int RateSystemId { get; set; }
    }
}
