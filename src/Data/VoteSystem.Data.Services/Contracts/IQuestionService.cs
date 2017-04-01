using System.Linq;
using VoteSystem.Data.Models;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IQuestionService
    {
        void Add(Question question);

        void Delete(Question question);

        IQueryable<Question> GetAllQuestions(string rateSystemId);

        IQueryable<Question> GetAllQuestions(int rateSystemId);

        IQueryable<Question> GetUsersAnswers(int rateSystemId);
    }
}
