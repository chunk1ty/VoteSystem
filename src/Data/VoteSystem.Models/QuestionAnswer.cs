using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoteSystem.Data.Entities.Contracts;

namespace VoteSystem.Data.Entities
{
    public class QuestionAnswer : IAuditInfo
    {
        public int Id { get; set; }

        public string QuestionAnswerName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int QuestionId { get; set; }
    }
}
