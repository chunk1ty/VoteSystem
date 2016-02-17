namespace VoteSystem.Web.ViewModels
{
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class QuestionViewModel : IMapFrom<Question>, IMapTo<Question>
    {
        public string QuestionName { get; set; }

        public int RateSystemId { get; set; }
    }
}