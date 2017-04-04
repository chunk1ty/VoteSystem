using System.Collections.Generic;
using System.Linq;
using VoteSystem.Data.DTO;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IVoteSystemService
    {
        void Add(SurveyDto system);

        void Delete(int rateSystemId);

        void Update(SurveyDto system);

        IEnumerable<SurveyDto> GetAll();

        IEnumerable<SurveyDto> AllActive(string userId);

        SurveyDto GetById(int rateSystemId);
    }
}
