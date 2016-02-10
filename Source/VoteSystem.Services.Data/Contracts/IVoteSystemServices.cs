namespace VoteSystem.Services.Data.Contracts
{
    using System.Linq;

    using VoteSystem.Models;

    public interface IVoteSystemServices
    {
        IQueryable<VoteSystem> GetAll();
    }
}
