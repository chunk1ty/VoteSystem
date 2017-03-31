using System.Linq;

using VoteSystem.Data.Models;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IRateSystemService
    {
        void Add(Models.Survey system);

        void Delete(int rateSystemId);

        void Update(Models.Survey system);

        IQueryable<Models.Survey> GetAll();

        IQueryable<Models.Survey> AllActive(string userId);

       Models.Survey GetById(int rateSystemId);

        void SaveChanges();
    }
}
