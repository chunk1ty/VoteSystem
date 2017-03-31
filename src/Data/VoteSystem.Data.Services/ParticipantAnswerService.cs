using VoteSystem.Data.Contracts;
using VoteSystem.Data.Models;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class ParticipantAnswerService : IParticipantAnswerService
    {
        private readonly IEntityFrameworkRepository<ParticipantAnswer> userAnswers;

        public ParticipantAnswerService(IEntityFrameworkRepository<ParticipantAnswer> userAnswers)
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
