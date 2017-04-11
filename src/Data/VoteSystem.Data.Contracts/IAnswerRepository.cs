using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Contracts
{
    public interface IAnswerRepository
    {
        void Add(Answer questionAndAnswers);
    }
}
