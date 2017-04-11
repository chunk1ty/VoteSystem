using System.Collections.Generic;

namespace VoteSystem.Data.Entities
{
    public class Participant
    {
        public Participant()
        {
            ParticipantAnswers = new HashSet<ParticipantAnswer>();
        }
       
        public int Id { get; set; }

        public bool IsVoted { get; set; }

        public string VoteSystemUserId { get; set; }
        public virtual VoteSystemUser VoteSystemUser { get; set; }

        public int VoteSystemId { get; set; }
        public virtual VoteSystem VoteSystem { get; set; }

        public ICollection<ParticipantAnswer> ParticipantAnswers { get; set; }
    }
}
