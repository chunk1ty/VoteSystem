using System.Collections.Generic;
using VoteSystem.Data.Entities;

namespace VotySystem.Data.DTO
{
    public class VoteSystemParticipantsDto
    {
        public VoteSystemParticipantsDto()
        {
            SelectedVoteSystemUsers = new List<VoteSystemUser>();
        }

        public int VoteSystemId { get; set; }
        
        public IList<VoteSystemUser> SelectedVoteSystemUsers { get; set; }
    }
}
