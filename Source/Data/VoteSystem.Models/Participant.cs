namespace VoteSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Participant
    {
        public Participant()
        {
            this.ParticipantAnswers = new HashSet<ParticipantAnswer>();
        }

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int RateSystemId { get; set; }

        public virtual RateSystem RateSystem { get; set; }

        public ICollection<ParticipantAnswer> ParticipantAnswers { get; set; }
    }
}
