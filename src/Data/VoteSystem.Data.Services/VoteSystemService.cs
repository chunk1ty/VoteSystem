using System.Collections.Generic;

using VoteSystem.Data.Contracts;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class VoteSystemService : IVoteSystemService
    {
        private readonly IVoteSystemRepository voteSystemRepository;

        public VoteSystemService(IVoteSystemRepository voteSystemRepository)
        {
            this.voteSystemRepository = voteSystemRepository;
        }

        public void Add(SurveyDto system)
        {
            //this.voteSystemRepository.Add(system);
        }

        public void Delete(int rateSystemId)
        {
            var rateSystem = this.voteSystemRepository.GetById(rateSystemId);
            this.voteSystemRepository.Delete(rateSystem);
        }

        public void Update(SurveyDto system)
        {
            //this.voteSystemRepository.Update(system);
        }

        public IEnumerable<SurveyDto> GetAll()
        {
            //return this.voteSystemRepository.All();
            return null;
        }

        public IEnumerable<SurveyDto> AllActive(string userId)
        {
            // TODO fix it later
            //return this.voteSystemRepository
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
            //return this.voteSystemRepository.GetById(rateSystemId);
            return null;
        }
    }
}
