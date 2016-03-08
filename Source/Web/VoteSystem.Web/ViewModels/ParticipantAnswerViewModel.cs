namespace VoteSystem.Web.ViewModels
{
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class ParticipantAnswerViewModel : IMapFrom<ParticipantAnswer>
    {
        public int Answer { get; set; }
    }
}