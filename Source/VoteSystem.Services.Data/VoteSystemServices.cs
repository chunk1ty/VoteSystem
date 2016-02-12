namespace VoteSystem.Services.Data
{
    using System.Linq;

    using VoteSystem.Data.Models;
    using VoteSystem.Data.Repositories;
    using VoteSystem.Services.Data.Contracts;

    public class VoteSystemServices : IVoteSystemServices
    {
        private readonly IRepository<VoteSystem> voteSystems;

        public VoteSystemServices(IRepository<VoteSystem> voteSystems)
        {
            this.voteSystems = voteSystems;
        }

        public IQueryable<VoteSystem> GetAll()
        {
            return this.voteSystems.All();
        }
    }
}
