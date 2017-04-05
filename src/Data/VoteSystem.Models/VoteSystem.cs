using System;
using System.Collections.Generic;
using VoteSystem.Data.Entities.Contracts;

namespace VoteSystem.Data.Entities
{
    public class VoteSystem : IDeletableEntity, IAuditInfo
    {
        public VoteSystem()
        {
            this.Questions = new HashSet<Question>();
            this.Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public DateTime StarDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Participant> Participants { get; set; }
    }
}
