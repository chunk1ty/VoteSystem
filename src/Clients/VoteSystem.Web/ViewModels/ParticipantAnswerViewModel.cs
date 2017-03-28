using VoteSystem.Data.Models;
using VoteSystem.Web.Infrastructure.Mapping;

namespace VoteSystem.Clients.MVC.ViewModels
{
    public class ParticipantAnswerViewModel : IMapFrom<ParticipantAnswer>
    {
        public int Answer { get; set; }
    }
}