using System.Linq;
using VoteSystem.Authentication.Models;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<AspNetUser> GetAllUnselectUsers(int rateSystemId);

        IQueryable<AspNetUser> GetAllSelectUsers(int rateSystemId);
    }
}
