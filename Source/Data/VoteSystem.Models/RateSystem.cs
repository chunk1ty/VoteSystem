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
            this.Participants = new HashSet<Participant>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string RateSystemName { get; set; }
       
        public DateTime StarDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Participant> Participants { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
