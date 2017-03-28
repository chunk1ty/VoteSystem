namespace VoteSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;
   
    public class UserService : IUserService
    {
        private IDbGenericRepository<User> users;
        private IParticipantService participants;

        public UserService(IDbGenericRepository<User> users, IParticipantService participants)
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
