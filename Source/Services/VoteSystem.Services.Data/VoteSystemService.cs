namespace VoteSystem.Services.Data
{
    using System.Linq;

    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;

    public class VoteSystemService : IVoteSystemService
    {
        private readonly IDbGenericRepository<VoteSystem> voteSystems;

        public VoteSystemService(IDbGenericRepository<VoteSystem> voteSystems)
        {
            this.voteSystems = voteSystems;
        }

        public IQueryable<VoteSystem> GetAll()
        {
            return this.voteSystems.All();
        }
    }
}
