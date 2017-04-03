using System.Linq;
using VoteSystem.Data.DTO;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IQuestionService
    {
        void Add(QuestionDto question);

        void Delete(QuestionDto question);

        IQueryable<QuestionDto> GetAllQuestions(string rateSystemId);

        IQueryable<QuestionDto> GetAllQuestions(int rateSystemId);

        IQueryable<QuestionDto> GetUsersAnswers(int rateSystemId);
    }
}
