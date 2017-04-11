using System.Collections.Generic;

using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IVoteSystemUserService
    {
        IEnumerable<VoteSystemUser> GetAllUnselectUsers(int voteSystemId);

        IEnumerable<VoteSystemUser> GetAllSelectUsers(int voteSystemId);
    }
}
