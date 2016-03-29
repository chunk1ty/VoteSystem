namespace VoteSystem.Services.Data.Contracts
{
    using VoteSystem.Data.Models;

    public interface IParticipantService
    {
        void Add(Participant participant);

        void Remove(Participant participant);

        void Update(Participant participant);

        Participant GetParticipantByRateSystemIdAndUserId(int rateSystemId, string userId);

        void SaveChanges();
    }
}
