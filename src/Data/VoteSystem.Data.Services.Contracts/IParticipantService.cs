using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IParticipantService
    {
        void Add(Participant participant);

        void Remove(Participant participant);

        void Update(Participant participant);

        Participant GetParticipantBySurveyIdAndUserId(int rateSystemId, string userId);
    }
}
