namespace VoteSystem.Web.ViewModels.FillRateSystem
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class FillQuestionsViewModel : IMapFrom<Question>, IMapTo<Question>
    {
        public FillQuestionsViewModel()
        {
            this.QuestionAnswers = new List<QuestionAnswerViewModel>();
        }
        
        public string QuestionName { get; set; }

        public int RateSystemId { get; set; }

        public IList<QuestionAnswerViewModel> QuestionAnswers { get; set; }
    }
}