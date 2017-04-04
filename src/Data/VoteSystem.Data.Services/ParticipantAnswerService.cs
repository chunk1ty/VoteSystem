using VoteSystem.Data.Contracts;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class ParticipantAnswerService : IParticipantAnswerService
    {
        private readonly IParticipantAnswerRepository participantAnswerRepository;

        public ParticipantAnswerService(IParticipantAnswerRepository participantAnswerRepository)
        {
            this.participantAnswerRepository = participantAnswerRepository;
        }

        public void Add(ParticipantAnswerDto userAnswers)
        {
            // TODO add mapping logic
            ParticipantAnswer p = new ParticipantAnswer();
            this.participantAnswerRepository.Add(p);
        }
    }
}
