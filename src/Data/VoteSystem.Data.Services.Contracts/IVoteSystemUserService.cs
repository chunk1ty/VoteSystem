using System.Collections.Generic;

using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IVoteSystemUserService
    {
        IEnumerable<VoteSystemUser> GetUnselectedUsers(int voteSystemId);

        IEnumerable<VoteSystemUser> GetSelectedUsers(int voteSystemId);
    }
}
