namespace VoteSystem.Data.Models
{
    using System.Collections.Generic;

    using VoteSystem.Data.Common.Models;

    public class Question : BaseModel<int>
    {
        public Question()
        {
            this.QuestionAnswers = new HashSet<QuestionAnswers>();
        }

        public string QuestionName { get; set; }

        public int RateSystemId { get; set; }

        public virtual RateSystem RateSystem { get; set; }

        public ICollection<QuestionAnswers> QuestionAnswers { get; set; }
    }
}
