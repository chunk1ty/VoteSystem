using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;
using VotySystem.Data.DTO;

namespace VoteSystem.Data.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IVoteSystemEfDbContextSaveChanges _dbContextSaveChanges;

        public ParticipantService(IParticipantRepository participantRepository, IVoteSystemEfDbContextSaveChanges dbContextSaveChanges)
        {
            _participantRepository = participantRepository;
            _dbContextSaveChanges = dbContextSaveChanges;
        }

        public void Add(Participant participant)
        {
            _participantRepository.Add(participant);

            _dbContextSaveChanges.SaveChanges();
        }

        public void AddParticipants(VoteSystemParticipantsDto voteSystemParticipants)
        {
            var voteSystemId = voteSystemParticipants.VoteSystemId;

            foreach (var user in voteSystemParticipants.SelectedVoteSystemUsers)
            {
                var currentParticipant = new Participant()
                {
                    VoteSystemId = voteSystemId,
                    VoteSystemUserId = user.Id.ToString()
                };

                _participantRepository.Add(currentParticipant);
            }

            _dbContextSaveChanges.SaveChanges();
        }

        public void Update(Participant participant)
        {
            _participantRepository.Update(participant);

            _dbContextSaveChanges.SaveChanges();
        }

        public void Remove(Participant participant)
        {
            _participantRepository.Delete(participant);

            _dbContextSaveChanges.SaveChanges();
        }

        public Participant GetParticipantBySurveyIdAndUserId(int voteSystemId, string userId)
        {
            var participant = _participantRepository
                                                .All()
                                                .FirstOrDefault(x => x.VoteSystemId == voteSystemId && x.VoteSystemUserId == userId);

            return participant;
        }
    }
}
