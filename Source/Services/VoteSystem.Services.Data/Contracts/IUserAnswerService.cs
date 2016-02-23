namespace VoteSystem.Services.Data.Contracts
{
    using VoteSystem.Data.Models;

    public interface IUserAnswerService
    {
        void Add(UserAnswer userAnswers);

        void SaveChanges();
    }
}
