namespace VoteSystem.Services.Data
{
    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;

    public class UserAnswerService : IUserAnswerService
    {
        private readonly IDbGenericRepository<ParticipantAnswer> userAnswers;

        public UserAnswerService(IDbGenericRepository<ParticipantAnswer> userAnswers)
        {
            this.userAnswers = userAnswers;
        }

        public void Add(ParticipantAnswer userAnswers)
        {
            this.userAnswers.Add(userAnswers);
        }

        public void SaveChanges()
        {
            this.userAnswers.SaveChanges();
        }
    }
}
