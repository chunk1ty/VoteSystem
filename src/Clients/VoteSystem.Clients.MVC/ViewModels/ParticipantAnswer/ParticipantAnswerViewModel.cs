using VoteSystem.Clients.MVC.Infrastructure.Mapping.Contracts;

namespace VoteSystem.Clients.MVC.ViewModels.ParticipantAnswer
{
    public class ParticipantAnswerViewModel : IMapFrom<Data.Entities.Answer>, IMapTo<Data.Entities.Answer>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }
}