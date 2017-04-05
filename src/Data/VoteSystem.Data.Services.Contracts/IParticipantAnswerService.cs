using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IParticipantAnswerService
    {
        void Add(ParticipantAnswer userAnswers);
    }
}
