namespace VoteSystem.Services.Data
{
    using System.Linq;

    using VoteSystem.Data.Models;
    using VoteSystem.Data.Common;
    using VoteSystem.Services.Data.Contracts;

    public class VoteSystemServices : IVoteSystemServices
    {
        private readonly IDbGenericRepository<VoteSystem> voteSystems;

        public VoteSystemServices(IDbGenericRepository<VoteSystem> voteSystems)
        {
            this.voteSystems = voteSystems;
        }

        public IQueryable<VoteSystem> GetAll()
        {
            return this.voteSystems.All();
        }
    }
}
