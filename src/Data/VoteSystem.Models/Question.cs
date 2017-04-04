using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoteSystem.Data.Entities.Contracts;

namespace VoteSystem.Data.Entities
{
    public class Question : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public bool HasMultipleAnswers { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public int RateSystemId { get; set; }
    }
}
