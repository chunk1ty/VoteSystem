using System.Collections.Generic;

using VoteSystem.Clients.MVC.Infrastructure.Mapping.Contracts;
using VoteSystem.Data.Entities;

namespace VoteSystem.Clients.MVC.ViewModels.ParticipantAnswer
{
    public class ParticipantQuestionViewModel : IMapFrom<Question>, IMapTo<Question>
    {
        public ParticipantQuestionViewModel()
        {
            Answers = new List<ParticipantAnswerViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        // dummy way to detect user answer when question has radio group
        public string RadioGroupQuestion { get; set; }

        public bool HasMultipleAnswers { get; set; }

        public int VoteSystemId { get; set; }

        public IList<ParticipantAnswerViewModel> Answers { get; set; }
    }
}