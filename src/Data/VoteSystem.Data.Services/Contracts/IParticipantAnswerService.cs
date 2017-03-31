using VoteSystem.Data.Models;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IParticipantAnswerService
    {
        void Add(ParticipantAnswer userAnswers);

        void SaveChanges();
    }
}
