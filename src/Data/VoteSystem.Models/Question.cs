using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoteSystem.Data.Entities.Contracts;

namespace VoteSystem.Data.Entities
{
    public class Question : IAuditInfo, IDeletableEntity
    {
        public Question()
        {
            this.QuestionAnswers = new HashSet<QuestionAnswer>();
        }

        public int Id { get; set; }

        public string QuestionName { get; set; }

        public bool HasMultipleAnswers { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int VoteSystemId { get; set; }
        public virtual VoteSystem VoteSystem { get; set; }

        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
