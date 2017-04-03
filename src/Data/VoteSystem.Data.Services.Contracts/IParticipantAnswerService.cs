using VoteSystem.Data.DTO;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IParticipantAnswerService
    {
        void Add(ParticipantAnswerDto userAnswers);
    }
}
