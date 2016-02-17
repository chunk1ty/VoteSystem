namespace VoteSystem.Data.Models
{
    using Common.Models;
    using System.Collections.Generic;

    public class QuestionAnswers : BaseModel<int>
    {
        public string QuestionAnswerName { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
