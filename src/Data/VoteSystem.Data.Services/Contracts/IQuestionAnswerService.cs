using VoteSystem.Data.Models;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IQuestionAnswerService
    {
        void Add(QuestionAnswer questionAndAnswers);

        void SaveChanges();
    }
}
