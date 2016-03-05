namespace VoteSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using VoteSystem.Data.Common.Models;
   
    public class ParticipantAnswer : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        public int Answer { get; set; }

        public string ParticipantId { get; set; }

        public virtual Participant Participant { get; set; }

        public int QuestionAnswerId { get; set; }

        public virtual QuestionAnswer QuestionAnswer { get; set; }
    }
}
