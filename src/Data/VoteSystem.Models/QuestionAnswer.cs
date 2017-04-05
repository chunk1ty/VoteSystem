using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoteSystem.Data.Entities.Contracts;

namespace VoteSystem.Data.Entities
{
    public class QuestionAnswer : IAuditInfo
    {
        public QuestionAnswer()
        {
            this.ParticipantAnswers = new HashSet<ParticipantAnswer>();
        }

        public int Id { get; set; }

        public string QuestionAnswerName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public ICollection<ParticipantAnswer> ParticipantAnswers { get; set; }
    }
}
