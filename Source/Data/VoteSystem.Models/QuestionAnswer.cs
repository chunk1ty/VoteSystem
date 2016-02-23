namespace VoteSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using VoteSystem.Data.Common.Models;

    public class QuestionAnswer : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        public string QuestionAnswerName { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
