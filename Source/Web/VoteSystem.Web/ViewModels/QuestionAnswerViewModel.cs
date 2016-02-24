namespace VoteSystem.Web.ViewModels
{
    using System.Collections.Generic;
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class QuestionAnswerViewModel : IMapFrom<QuestionAnswer>, IMapTo<QuestionAnswer>
    {
        public int Id { get; set; }

        public string QuestionAnswerName { get; set; }

        public int QuestionId { get; set; }

        public IList<UserAnswerViewModel> UserAnswers { get; set; }
    }
}