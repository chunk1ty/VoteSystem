namespace VoteSystem.Services.Data.Contracts
{
    using System.Linq;

    using VoteSystem.Data.Models;

    public interface IRateSystemService
    {
        void Add(RateSystem system);

        void SaveChanges();

        IQueryable<RateSystem> GetAll();

        IQueryable<RateSystem> AllActive();
    }
}
