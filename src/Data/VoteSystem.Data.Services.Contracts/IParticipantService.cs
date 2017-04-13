using System;
using System.Collections.Generic;

using VoteSystem.Data.Entities;
using VotySystem.Data.DTO;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IParticipantService
    {
        void Add(Participant participant);

        void AddParticipants(VoteSystemParticipantsDto voteSystemParticipants);

        void Remove(Participant participant);

        void RemoveParticipants(IEnumerable<Participant> participants);

        void Update(Participant participant);

        Participant GetParticipantBySurveyIdAndUserId(int voteSystemId, Guid userId);

        IEnumerable<Participant> GetParticipantsByVoteSystemId(int voteSystemId);
    }
}
