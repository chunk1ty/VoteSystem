using VoteSystem.Data.Contracts;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class ParticipantService : IParticipantService
    {
        private IRepository<Participant> participants;

        public ParticipantService(IRepository<Participant> participants)
        {
            this.participants = participants;
        }

        public void Add(ParticipantDto participant)
        {
            // TODO add mapping logic
            //this.participants.Add(participant);
        }

        public void Update(ParticipantDto participant)
        {
            // TODO add mapping logic
            //this.participants.Update(participant);
        }

        public void Remove(ParticipantDto participant)
        {
            // TODO add mapping logic
            //this.participants.Delete(participant);
        }

        public ParticipantDto GetParticipantByRateSystemIdAndUserId(int rateSystemId, string userId)
        {
            // TODO add mapping logic
            // TODO fix it later
            //return this.participants
            //    .All()
            //    .Where(x => x.RateSystemId == rateSystemId && x.UserId == userId)
            //    .FirstOrDefault();

            return null;
        }
    }
}
