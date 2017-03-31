using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.Models;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class UserService : IUserService
    {
        private IEntityFrameworkRepository<User> users;
        private IParticipantService participants;

        public UserService(IEntityFrameworkRepository<User> users, IParticipantService participants)
        {
            this.users = users;
            this.participants = participants;
        }
       
        public IQueryable<User> GetAllUnselectUsers(int rateSystemId)
        {
            var allUsers = this.users
                .All();

            return allUsers
                    .Except(this.GetAllSelectUsers(rateSystemId));
        }

        public IQueryable<User> GetAllSelectUsers(int rateSystemId)
        {
            return this.users
                .All()
                .Where(
                     x => x.Participants
                            .Any(
                                y => y.RateSystemId == rateSystemId));
        }
    }
}
