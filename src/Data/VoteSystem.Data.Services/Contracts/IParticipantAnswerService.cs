using VoteSystem.Data.DtoModels;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IParticipantAnswerService
    {
        void Add(ParticipantAnswerDto userAnswers);
    }
}
