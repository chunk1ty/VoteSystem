namespace VoteSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using VoteSystem.Data.Common.Models;
   
    public class UserAnswer : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        public int Answer { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int QuestionAnswerId { get; set; }

        public virtual QuestionAnswer QuestionAnswer { get; set; }
    }
}
