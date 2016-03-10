namespace VoteSystem.Services.Data
{
    using System.Linq;

    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;

    public class ParticipantService : IParticipantService
    {
        private IDbGenericRepository<Participant> participants;

        public ParticipantService(IDbGenericRepository<Participant> participants)
        {
            this.participants = participants;
        }

        public void Add(Participant participant)
        {
            this.participants.Add(participant);
        }

        public void Remove(Participant participant)
        {
            this.participants.Delete(participant);
        }

        public Participant GetParticipantByRateSystemIdAndUserId(int rateSystemId, string userId)
        {
            return this.participants
                .All()
                .Where(x => x.RateSystemId == rateSystemId && x.UserId == userId)
                .FirstOrDefault();
        }

        public void SaveChanges()
        {
            this.participants.SaveChanges();
        }
    }
}
