namespace VoteSystem.Services.Data.Contracts
{
    using System.Linq;
    using VoteSystem.Data.Models;

    public interface IQuestionService
    {
        void Add(Question question);

        void SaveChanges();

        IQueryable<Question> GetAll(int rateSystemId);
    }
}
