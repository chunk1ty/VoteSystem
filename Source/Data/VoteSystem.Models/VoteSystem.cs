namespace VoteSystem.Data.Models
{    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;

    public class VoteSystem : BaseModel<int>
    {
        public VoteSystem()
        {
            this.Questions = new HashSet<Question>();
            this.Users = new HashSet<User>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        //TODO make sure that these properties are not nullable
        public DateTime? StarDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
