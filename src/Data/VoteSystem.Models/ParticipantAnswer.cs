using System;

using VoteSystem.Data.Entities.Contracts;

namespace VoteSystem.Data.Entities
{
    public class ParticipantAnswer : IAuditInfo
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ParticipantId { get; set; }

        public int QuestionAnswerId { get; set; }
    }
}
