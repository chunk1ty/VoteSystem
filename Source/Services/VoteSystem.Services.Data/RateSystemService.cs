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
            this.SaveChanges();
        }

        public void Delete(int rateSystemId)
        {
            var rateSystem = this.rateSystems.GetById(rateSystemId);
            this.rateSystems.Delete(rateSystem);

            this.SaveChanges();
        }

        public void Update(RateSystem system)
        {
            this.rateSystems.Update(system);
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            this.rateSystems.SaveChanges();
        }

        public IQueryable<RateSystem> GetAll()
        {
            return this.rateSystems.All();
        }

        public IQueryable<RateSystem> AllActive(string userId)
        {
            return this.rateSystems
                    .All()
                    .Where(x => 
                            x.StarDateTime <= DateTime.Now && 
                            DateTime.Now <= x.EndDateTime &&
                            x.Participants.Any(y =>
                                                y.UserId == userId));
        }

        public RateSystem GetById(int rateSystemId)
        {
            return this.rateSystems.GetById(rateSystemId);
        }
    }
}
