using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.DtoModels;
using VoteSystem.Data.Models;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class UserService : IUserService
    {
        private IEntityFrameworkRepository<VoteSystemUser> users;
        private IParticipantService participants;

        public UserService(IEntityFrameworkRepository<VoteSystemUser> users, IParticipantService participants)
        {
            this.users = users;
            this.participants = participants;
        }
       
        public IQueryable<VoteSystemUserDto> GetAllUnselectUsers(int rateSystemId)
        {
            //var allUsers = this.users
            //    .All();

            //return allUsers
            //        .Except(this.GetAllSelectUsers(rateSystemId));
            return null;
        }

        public IQueryable<VoteSystemUserDto> GetAllSelectUsers(int rateSystemId)
        {
            //return this.users
            //    .All()
            //    .Where(
            //         x => x.Participants
            //                .Any(
            //                    y => y.RateSystemId == rateSystemId));

            return null;
        }
    }
}
