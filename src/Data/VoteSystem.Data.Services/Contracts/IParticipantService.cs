using VoteSystem.Data.Models;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IParticipantService
    {
        void Add(Participant participant);

        void Remove(Participant participant);

        void Update(Participant participant);

        Participant GetParticipantByRateSystemIdAndUserId(int rateSystemId, string userId);
    }
}
