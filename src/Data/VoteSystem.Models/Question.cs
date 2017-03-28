namespace VoteSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using VoteSystem.Data.Common.Models;

    public class Question : DeletableEntity, IAuditInfo
    {
        public Question()
        {
            this.QuestionAnswers = new HashSet<QuestionAnswer>();
        }
        
        [Key]
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public bool HasMultipleAnswers { get; set; }

        public int RateSystemId { get; set; }

        public virtual RateSystem RateSystem { get; set; }

        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
