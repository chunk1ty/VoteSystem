using VoteSystem.Data.Contracts;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class ParticipantAnswerService : IParticipantAnswerService
    {
        private readonly IRepository<ParticipantAnswer> userAnswers;

        public ParticipantAnswerService(IRepository<ParticipantAnswer> userAnswers)
        {
            this.userAnswers = userAnswers;
        }

        public void Add(ParticipantAnswerDto userAnswers)
        {
            // TODO add mapping logic
            ParticipantAnswer p = new ParticipantAnswer();
            this.userAnswers.Add(p);
        }
    }
}
