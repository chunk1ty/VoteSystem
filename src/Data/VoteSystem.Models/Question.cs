using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoteSystem.Data.Models.Contracts;

namespace VoteSystem.Data.Models
{
    public class Question : IAuditInfo, IDeletableEntity
    {
        public Question()
        {
            this.QuestionAnswers = new HashSet<QuestionAnswer>();
        }
        
        [Key]
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public bool HasMultipleAnswers { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public int RateSystemId { get; set; }
        public virtual Survey RateSystem { get; set; }

        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
