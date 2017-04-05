using VoteSystem.Data.Contracts;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class ParticipantAnswerService : IParticipantAnswerService
    {
        private readonly IParticipantAnswerRepository _participantAnswerRepository;
        private readonly IVoteSystemEfDbContextSaveChanges _dbContextSaveChanges;

        public ParticipantAnswerService(IParticipantAnswerRepository participantAnswerRepository, IVoteSystemEfDbContextSaveChanges dbContextSaveChanges)
        {
            _participantAnswerRepository = participantAnswerRepository;
            _dbContextSaveChanges = dbContextSaveChanges;
        }

        public void Add(ParticipantAnswer userAnswers)
        {
            // TODO add mapping logic
            //ParticipantAnswer p = new ParticipantAnswer();
            _participantAnswerRepository.Add(userAnswers);

            _dbContextSaveChanges.SaveChanges();
        }
    }
}
