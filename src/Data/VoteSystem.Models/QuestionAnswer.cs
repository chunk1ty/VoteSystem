namespace VoteSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using VoteSystem.Data.Common.Models;
    
    public class QuestionAnswer : AuditInfo
    {
        public QuestionAnswer()
        {
            this.ParticipantAnswers = new HashSet<ParticipantAnswer>();
        }

        [Key]
        public int Id { get; set; }

        public string QuestionAnswerName { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public ICollection<ParticipantAnswer> ParticipantAnswers { get; set; }
    }
}
