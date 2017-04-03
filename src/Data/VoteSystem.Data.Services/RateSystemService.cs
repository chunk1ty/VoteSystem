using System;
using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class RateSystemService : IRateSystemService
    {
        private readonly IDeletableRepository<Survey> rateSystems;

        public RateSystemService(IDeletableRepository<Survey> rateSystems)
        {
            this.rateSystems = rateSystems;
        }

        public void Add(SurveyDto system)
        {
            //this.rateSystems.Add(system);
        }

        public void Delete(int rateSystemId)
        {
            var rateSystem = this.rateSystems.GetById(rateSystemId);
            this.rateSystems.Delete(rateSystem);
        }

        public void Update(SurveyDto system)
        {
            //this.rateSystems.Update(system);
        }

        public IQueryable<SurveyDto> GetAll()
        {
           // return this.rateSystems.All();
            return null;
        }

        public IQueryable<SurveyDto> AllActive(string userId)
        {
            // TODO fix it later
            //return this.rateSystems
            //        .All()
            //        .Where(x => 
            //                x.StarDateTime <= DateTime.Now && 
            //                DateTime.Now <= x.EndDateTime &&
            //                x.Participants.Any(y =>
            //                                    y.UserId == userId &&
            //                                    y.IsVoted == false));

            return null;
        }

        public SurveyDto GetById(int rateSystemId)
        {
            //return this.rateSystems.GetById(rateSystemId);
            return null;
        }
    }
}
