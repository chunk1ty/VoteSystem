using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Contracts
{
    public interface IQuestionAnswerRepository
    {
        void Add(Answer questionAndAnswers);
    }
}
