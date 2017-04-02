using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteSystem.Data.Models
{
    public class VoteSystemUser
    {
        public VoteSystemUser()
        {
            this.Participants = new HashSet<Participant>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Participant> Participants { get; set; }
    }
}
