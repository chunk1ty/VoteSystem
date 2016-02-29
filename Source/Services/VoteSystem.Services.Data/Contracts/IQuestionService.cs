namespace VoteSystem.Services.Data.Contracts
{
    using System.Linq;

    using VoteSystem.Data.Models;

    public interface IQuestionService
    {
        void Add(Question question);

        void Delete(Question question);

        IQueryable<Question> GetAllQuestions(int rateSystemId);

        IQueryable<Question> GetUsersAnswers(int rateSystemId);

        void SaveChanges();
    }
}
