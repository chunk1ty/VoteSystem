using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.Models;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class ParticipantService : IParticipantService
    {
        private IEntityFrameworkRepository<Participant> participants;

        public ParticipantService(IEntityFrameworkRepository<Participant> participants)
        {
            this.participants = participants;
        }

        public void Add(Participant participant)
        {
            this.participants.Add(participant);
        }

        public void Update(Participant participant)
        {
            this.participants.Update(participant);
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
