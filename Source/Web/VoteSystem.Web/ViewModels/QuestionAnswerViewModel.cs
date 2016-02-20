namespace VoteSystem.Web.ViewModels
{
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class QuestionAnswerViewModel : IMapFrom<QuestionAnswers>, IMapTo<QuestionAnswers>
    {
        public string QuestionAnswerName { get; set; }

        public int QuestionId { get; set; }
    }
}