namespace VoteSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using VoteSystem.Data.Common.Models;

    public class Question : AuditInfo
    {
        public Question()
        {
            this.QuestionAnswers = new HashSet<QuestionAnswer>();
            this.UserAnswers = new HashSet<UserAnswer>();
        }
        
        [Key]
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public int RateSystemId { get; set; }

        public virtual RateSystem RateSystem { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }

        public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
