using VoteSystem.Data.DTO;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IQuestionAnswerService
    {
        void Add(QuestionAnswerDto questionAndAnswers);
    }
}
