using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IQuestionAnswerService
    {
        void Add(Answer questionAndAnswers);
    }
}
