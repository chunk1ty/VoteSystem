using System.Linq;

using VoteSystem.Data.Models;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetAllUnselectUsers(int rateSystemId);

        IQueryable<User> GetAllSelectUsers(int rateSystemId);
    }
}
