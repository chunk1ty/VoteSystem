using System.Collections.Generic;
using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IVoteSystemUserService
    {
        // TODO use encoded votesystem id
        IEnumerable<VoteSystemUser> GetUnselectedVoteSystemUsersByVoteSystemId(int voteSystemId);
    }
}
