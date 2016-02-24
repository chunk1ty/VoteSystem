namespace VoteSystem.Data.Models
{    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using VoteSystem.Data.Common.Models;
   
    public class RateSystem : DeletableEntity, IAuditInfo
    {
        public RateSystem()
        {
            this.Questions = new HashSet<Question>();
            this.Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string RateSystemName { get; set; }
       
        public DateTime StarDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<User> Users { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
