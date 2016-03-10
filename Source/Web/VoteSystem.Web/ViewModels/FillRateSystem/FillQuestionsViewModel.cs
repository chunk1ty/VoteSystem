namespace VoteSystem.Web.ViewModels.FillRateSystem
{
    using System.Collections.Generic;

    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class FillQuestionsViewModel : IMapFrom<Question>, IMapTo<Question>
    {
        public FillQuestionsViewModel()
        {
            this.QuestionAnswers = new List<QuestionAnswerViewModel>();
        }
        
        public string QuestionName { get; set; }

        public bool HasMultipleAnswers { get; set; }

        public int RateSystemId { get; set; }

        public IList<QuestionAnswerViewModel> QuestionAnswers { get; set; }
    }
}