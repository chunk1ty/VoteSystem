namespace VoteSystem.Services.Data.Contracts
{
    using System.Linq;

    using VoteSystem.Data.Models;

    public interface IRateSystemService
    {
        IQueryable<RateSystem> GetAll();

        void Add(RateSystem system);

        IQueryable<RateSystem> AllActive();
    }
}
