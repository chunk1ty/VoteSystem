using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoteSystem.Data.Models.Contracts;

namespace VoteSystem.Data.Models
{
    public class QuestionAnswer : IAuditInfo
    {
        public QuestionAnswer()
        {
            this.ParticipantAnswers = new HashSet<ParticipantAnswer>();
        }

        [Key]
        public int Id { get; set; }

        public string QuestionAnswerName { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public ICollection<ParticipantAnswer> ParticipantAnswers { get; set; }
    }
}
