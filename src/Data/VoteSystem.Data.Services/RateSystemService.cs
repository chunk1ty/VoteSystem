using System;
using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.Models;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class RateSystemService : IRateSystemService
    {
        private readonly IDeletableEntityRepository<Models.Survey> rateSystems;

        public RateSystemService(IDeletableEntityRepository<Models.Survey> rateSystems)
        {
            this.rateSystems = rateSystems;
        }

        public void Add(Survey system)
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

        public void Update(Survey system)
        {
            this.rateSystems.Update(system);
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            this.rateSystems.SaveChanges();
        }

        public IQueryable<Survey> GetAll()
        {
            return this.rateSystems.All();
        }

        public IQueryable<Models.Survey> AllActive(string userId)
        {
            return this.rateSystems
                    .All()
                    .Where(x => 
                            x.StarDateTime <= DateTime.Now && 
                            DateTime.Now <= x.EndDateTime &&
                            x.Participants.Any(y =>
                                                y.UserId == userId &&
                                                y.IsVoted == false));
        }

        public Survey GetById(int rateSystemId)
        {
            return this.rateSystems.GetById(rateSystemId);
        }
    }
}
