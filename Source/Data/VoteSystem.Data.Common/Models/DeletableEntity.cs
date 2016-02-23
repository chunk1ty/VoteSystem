namespace VoteSystem.Data.Common.Models
{
    using System;

    public abstract class DeletableEntity : IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
