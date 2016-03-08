namespace VoteSystem.Services.Data.Contracts
{
    using System.Linq;

    using VoteSystem.Data.Models;

    public interface IRateSystemService
    {
        void Add(RateSystem system);

        void Delete(int rateSystemId);

        void Update(RateSystem system);

        IQueryable<RateSystem> GetAll();

        IQueryable<RateSystem> AllActive(string UserId);

        RateSystem GetById(int rateSystemId);

        void SaveChanges();
    }
}
