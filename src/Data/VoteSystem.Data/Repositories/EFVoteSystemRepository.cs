using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Repositories
{
    class EfVoteSystemRepository : IVoteSystemRepository
    {
        public void Add(Entities.VoteSystem system)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entities.VoteSystem voteSystem)
        {
            throw new NotImplementedException();
        }

        public Entities.VoteSystem GetById(int voteSystemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.VoteSystem> All()
        {
            throw new NotImplementedException();
        }
    }
}
