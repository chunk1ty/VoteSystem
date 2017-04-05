using System.Collections.Generic;
using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class VoteSystemUserService : IVoteSystemUserService
    {
        private readonly IVoteSystemUserRepository _voteSystemUserRepository;

        public VoteSystemUserService(IVoteSystemUserRepository voteSystemUserRepository)
        {
            this._voteSystemUserRepository = voteSystemUserRepository;
        }
       
        public IEnumerable<VoteSystemUser> GetAllUnselectUsers(int voteSystemId)
        {
            var allUsers = this._voteSystemUserRepository
                .GetAll();

            return allUsers
                    .Except(this.GetAllSelectUsers(voteSystemId));
        }

        public IEnumerable<VoteSystemUser> GetAllSelectUsers(int voteSystemId)
        {
            return this._voteSystemUserRepository
                .GetAll()
                .Where(
                     x => x.Participants
                            .Any(
                                y => y.VoteSystemId == voteSystemId));
        }
    }
}
