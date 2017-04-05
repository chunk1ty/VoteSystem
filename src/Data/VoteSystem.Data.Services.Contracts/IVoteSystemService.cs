using System.Collections.Generic;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IVoteSystemService
    {
        void Add(Entities.VoteSystem system);

        void Delete(int rateSystemId);

        void Update(Entities.VoteSystem system);

        IEnumerable<Entities.VoteSystem> GetAll();

        IEnumerable<Entities.VoteSystem> AllActive(string userId);

        Entities.VoteSystem GetById(int rateSystemId);
    }
}
