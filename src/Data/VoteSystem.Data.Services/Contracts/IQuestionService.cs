using System.Linq;
using VoteSystem.Data.DtoModels;
using VoteSystem.Data.Models;

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
