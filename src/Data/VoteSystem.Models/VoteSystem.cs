using System;

using VoteSystem.Data.Entities.Contracts;

namespace VoteSystem.Data.Entities
{
    public class VoteSystem : IDeletableEntity, IAuditInfo
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public DateTime StarDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
