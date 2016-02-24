namespace VoteSystem.Services.Data
{
    using System;
    using System.Linq;

    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;

    public class RateSystemService : IRateSystemService
    {
        private readonly IDeletableEntityRepository<RateSystem> rateSystems;

        public RateSystemService(IDeletableEntityRepository<RateSystem> rateSystems)
        {
            this.rateSystems = rateSystems;
        }

        public void Add(RateSystem system)
        {
            this.rateSystems.Add(system);
        }

        public void SaveChanges()
        {
            this.rateSystems.SaveChanges();
        }

        public IQueryable<RateSystem> GetAll()
        {
            return this.rateSystems.All();
        }

        public IQueryable<RateSystem> AllActive()
        {
            return this.rateSystems
                    .All()
                    .Where(x => x.StarDateTime <= DateTime.Now && DateTime.Now <= x.EndDateTime);
        }
    }
}
