namespace VoteSystem.Services.Data.Contracts
{
    using System.Linq;

    using VoteSystem.Data.Models;

    public interface IUserService
    {
        IQueryable<User> GetAll();
    }
}
