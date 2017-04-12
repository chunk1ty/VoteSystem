using VoteSystem.Data.Entities;
using VotySystem.Data.DTO;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IParticipantService
    {
        void Add(Participant participant);

        void AddParticipants(VoteSystemParticipantsDto voteSystemParticipants);

        void Remove(Participant participant);

        void Update(Participant participant);

        Participant GetParticipantBySurveyIdAndUserId(int rateSystemId, string userId);
    }
}
