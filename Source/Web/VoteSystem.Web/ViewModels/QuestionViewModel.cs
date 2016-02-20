namespace VoteSystem.Web.ViewModels
{
    using System.Collections.Generic;
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class QuestionViewModel : IMapFrom<Question>, IMapTo<Question>
    {
        public QuestionViewModel()
        {
            this.QuestionAnswers = new HashSet<QuestionAnswerViewModel>();
        }

        public string QuestionName { get; set; }

        public int RateSystemId { get; set; }

        public IEnumerable<QuestionAnswerViewModel> QuestionAnswers { get; set; }
    }
}