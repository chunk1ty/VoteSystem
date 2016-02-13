namespace VoteSystem.Services.Data
{
    using System.Linq;

    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;

    public class RateSystemService : IRateSystemService
    {
        private readonly IDbGenericRepository<RateSystem> rateSystems;

        public RateSystemService(IDbGenericRepository<RateSystem> rateSystems)
        {
            this.rateSystems = rateSystems;
        }

        public IQueryable<RateSystem> GetAll()
        {
            return this.rateSystems.All();
        }
    }
}
