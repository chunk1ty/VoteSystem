using VoteSystem.Data.Contracts;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class ParticipantService : IParticipantService
    {
        private IParticipantRepository participantRepository;

        public ParticipantService(IParticipantRepository participantRepository)
        {
            this.participantRepository = participantRepository;
        }

        public void Add(ParticipantDto participant)
        {
            // TODO add mapping logic
            //this.participantRepository.Add(participant);
        }

        public void Update(ParticipantDto participant)
        {
            // TODO add mapping logic
            //this.participantRepository.Update(participant);
        }

        public void Remove(ParticipantDto participant)
        {
            // TODO add mapping logic
            //this.participantRepository.Delete(participant);
        }

        public ParticipantDto GetParticipantBySurveyIdAndUserId(int rateSystemId, string userId)
        {
            // TODO add mapping logic
            // TODO fix it later
            //return this.participantRepository
             //   .All()
            //    .Where(x => x.RateSystemId == rateSystemId && x.UserId == userId)
            //    .FirstOrDefault();

            return null;
        }
    }
}
