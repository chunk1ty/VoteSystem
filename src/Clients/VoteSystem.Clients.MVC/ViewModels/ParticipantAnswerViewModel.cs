using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Data.Models;

namespace VoteSystem.Clients.MVC.ViewModels
{
    public class ParticipantAnswerViewModel : IMapFrom<ParticipantAnswer>
    {
        public int Answer { get; set; }
    }
}