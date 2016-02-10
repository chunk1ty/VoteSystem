namespace VoteSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class VoteSystem
    {
        public VoteSystem()
        {
            this.Questions = new HashSet<Question>();
            this.Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime StarDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
