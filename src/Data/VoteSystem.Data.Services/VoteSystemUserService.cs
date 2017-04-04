using System.Collections.Generic;
using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class VoteSystemUserService : IVoteSystemUserService
    {
        private IVoteSystemUserRepository voteSystemUserRepository;
        private IParticipantService participants;

        public VoteSystemUserService(IVoteSystemUserRepository voteSystemUserRepository, IParticipantService participants)
        {
            this.voteSystemUserRepository = voteSystemUserRepository;
            this.participants = participants;
        }
       
        public IEnumerable<VoteSystemUserDto> GetAllUnselectUsers(int rateSystemId)
        {
            //var allUsers = this.voteSystemUserRepository
            //    .All();

            //return allUsers
            //        .Except(this.GetAllSelectUsers(rateSystemId));
            return null;
        }

        public IEnumerable<VoteSystemUserDto> GetAllSelectUsers(int rateSystemId)
        {
            //return this.voteSystemUserRepository
            //    .All()
            //    .Where(
            //         x => x.Participants
            //                .Any(
            //                    y => y.RateSystemId == rateSystemId));

            return null;
        }
    }
}
