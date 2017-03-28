namespace VoteSystem.Services.Data.Contracts
{
    using VoteSystem.Data.Models;

    public interface IParticipantAnswerService
    {
        void Add(ParticipantAnswer userAnswers);

        void SaveChanges();
    }
}
