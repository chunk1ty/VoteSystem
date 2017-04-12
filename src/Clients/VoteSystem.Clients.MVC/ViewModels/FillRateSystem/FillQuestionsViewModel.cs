using System.Collections.Generic;
using VoteSystem.Clients.MVC.Areas.Administration.ViewModels.Answer;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Clients.MVC.Infrastructure.Mapping.Contracts;
using VoteSystem.Data.Entities;

namespace VoteSystem.Clients.MVC.ViewModels.FillRateSystem
{
    public class FillQuestionsViewModel : IMapFrom<Question>, IMapTo<Question>
    {
        public FillQuestionsViewModel()
        {
            this.QuestionAnswers = new List<AnswerViewModel>();
        }

        public int Id { get; set; }

        public string QuestionName { get; set; }

        // dummy way to detect user answer when question has radio group
        public string RadioGroupAnswer { get; set; }

        public bool HasMultipleAnswers { get; set; }

        public int RateSystemId { get; set; }

        public IList<AnswerViewModel> QuestionAnswers { get; set; }
    }
}