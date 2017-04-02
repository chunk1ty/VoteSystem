using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VoteSystem.Data.Models
{
    public class Participant
    {
        public Participant()
        {
            this.ParticipantAnswers = new HashSet<ParticipantAnswer>();
        }

        [Key]
        public int Id { get; set; }

        public bool IsVoted { get; set; }

        public ICollection<ParticipantAnswer> ParticipantAnswers { get; set; }

        public string VoteSystemUserId { get; set; }
        public virtual VoteSystemUser VoteSystemUser { get; set; }

        public int RateSystemId { get; set; }
        public virtual Survey RateSystem { get; set; }
    }
}
