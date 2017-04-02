using VoteSystem.Data.Contracts;
using VoteSystem.Data.DtoModels;
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

        public void Add(ParticipantAnswerDto userAnswers)
        {
            // TODO add mapping logic
            ParticipantAnswer p = new ParticipantAnswer();
            this.userAnswers.Add(p);
        }
    }
}
