using VoteSystem.Data.DtoModels;
using VoteSystem.Data.Models;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IQuestionAnswerService
    {
        void Add(QuestionAnswerDto questionAndAnswers);
    }
}
