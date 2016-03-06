namespace VoteSystem.Services.Data.Contracts
{
    using System.Linq;
    using VoteSystem.Data.Models;

    public interface IParticipantService
    {
        void Add(Participant participant);

        void Remove(Participant participant);

        Participant GetParticipantByRateSystemIdAndUserId(int rateSystemId, string UserId);

        void SaveChanges();
    }
}
