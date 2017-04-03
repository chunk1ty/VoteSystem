using VoteSystem.Data.DTO;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IParticipantService
    {
        void Add(ParticipantDto participant);

        void Remove(ParticipantDto participant);

        void Update(ParticipantDto participant);

        ParticipantDto GetParticipantByRateSystemIdAndUserId(int rateSystemId, string userId);
    }
}
