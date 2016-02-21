namespace VoteSystem.Services.Data
{
    using System;
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

        public void Add(RateSystem system)
        {
            this.rateSystems.Add(system);
            // TODO remove savechanges
            this.rateSystems.SaveChanges();
        }

        public IQueryable<RateSystem> AllActive()
        {
            return
                this.rateSystems.All()
                    .Where(x => x.StarDateTime <= DateTime.Now && DateTime.Now <= x.EndDateTime);
        }
    }
}
