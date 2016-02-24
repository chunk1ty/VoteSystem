namespace VoteSystem.Services.Data
{
    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;

    public class UserAnswerService : IUserAnswerService
    {
        private readonly IDbGenericRepository<UserAnswer> userAnswers;

        public UserAnswerService(IDbGenericRepository<UserAnswer> userAnswers)
        {
            this.userAnswers = userAnswers;
        }

        public void Add(UserAnswer userAnswers)
        {
            this.userAnswers.Add(userAnswers);
        }

        public void SaveChanges()
        {
            this.userAnswers.SaveChanges();
        }
    }
}
