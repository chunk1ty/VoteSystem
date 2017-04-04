using System.Collections.Generic;

namespace VoteSystem.Data.Contracts
{
    public interface IVoteSystemRepository
    {
        void Add(Entities.VoteSystem system);

        void Delete(Entities.VoteSystem voteSystem);

        Entities.VoteSystem GetById(int voteSystemId);

        IEnumerable<Entities.VoteSystem> All();
    }
}
