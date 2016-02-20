namespace VoteSystem.Data.Models
{
    using VoteSystem.Data.Common.Models;

    public class QuestionAnswers : BaseModel<int>
    {
        public string QuestionAnswerName { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
