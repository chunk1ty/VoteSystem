namespace VoteSystem.Web.ViewModels
{
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class UserAnswerViewModel : IMapFrom<UserAnswer>
    {
        public int Answer { get; set; }
    }
}