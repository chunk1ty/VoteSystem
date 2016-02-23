namespace VoteSystem.Data.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class UserAnswer : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        public int Answer { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
