using System;
using VoteSystem.Data.Models.Common;

namespace VoteSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ParticipantAnswer : IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }

        public int QuestionAnswerId { get; set; }
        public virtual QuestionAnswer QuestionAnswer { get; set; }
    }
}
