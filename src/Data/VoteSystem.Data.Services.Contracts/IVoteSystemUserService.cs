using System.Collections.Generic;
using System.Linq;
using VoteSystem.Data.DTO;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IVoteSystemUserService
    {
        IEnumerable<VoteSystemUserDto> GetAllUnselectUsers(int rateSystemId);

        IEnumerable<VoteSystemUserDto> GetAllSelectUsers(int rateSystemId);
    }
}
