using System.Linq;

using VoteSystem.Data.Models;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IRateSystemService
    {
        void Add(Survey system);

        void Delete(int rateSystemId);

        void Update(Survey system);

        IQueryable<Survey> GetAll();

        IQueryable<Survey> AllActive(string userId);

       Survey GetById(int rateSystemId);
    }
}
