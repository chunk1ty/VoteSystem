using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IAnswerService
    {
        void Add(Answer questionAndAnswers);
    }
}
