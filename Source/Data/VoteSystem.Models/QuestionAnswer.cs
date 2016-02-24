namespace VoteSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using VoteSystem.Data.Common.Models;
    
    public class QuestionAnswer : AuditInfo
    {
        public QuestionAnswer()
        {
            this.UserAnswers = new HashSet<UserAnswer>();
        }

        [Key]
        public int Id { get; set; }

        public string QuestionAnswerName { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
