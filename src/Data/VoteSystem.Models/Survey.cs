using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VoteSystem.Data.Entities.Contracts;

namespace VoteSystem.Data.Entities
{
    public class Survey : IDeletableEntity, IAuditInfo
    {
        public Survey()
        {
            this.Questions = new HashSet<Question>();
            this.Participants = new HashSet<Participant>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
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
