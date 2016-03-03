namespace VoteSystem.Services.Data
{
    using System.Linq;

    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;

    public class UserService : IUserService
    {
        private IDbGenericRepository<User> users;

        public UserService(IDbGenericRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }
    }
}
