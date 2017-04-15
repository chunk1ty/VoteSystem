using System;
using System.Collections.Generic;
using System.Linq;

using VoteSystem.Data.Contracts;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class VoteSystemService : IVoteSystemService
    {
        private readonly IVoteSystemRepository _voteSystemRepository;
        private readonly IVoteSystemEfDbContextSaveChanges _dbContextSaveChanges;

        public VoteSystemService(IVoteSystemRepository voteSystemRepository, IVoteSystemEfDbContextSaveChanges dbContextSaveChanges)
        {
            _voteSystemRepository = voteSystemRepository;
            _dbContextSaveChanges = dbContextSaveChanges;
        }

        public void Add(Entities.VoteSystem system)
        {
            _voteSystemRepository.Add(system);

            _dbContextSaveChanges.SaveChanges();
        }

        public void Delete(int voteSystemId)
        {
            // TODO how to do it with one query
            var voteSystem = this._voteSystemRepository.GetById(voteSystemId);

           _voteSystemRepository.Delete(voteSystem);

            _dbContextSaveChanges.SaveChanges();
        }

        public void Update(Entities.VoteSystem system)
        {
            _voteSystemRepository.Update(system);

            _dbContextSaveChanges.SaveChanges();
        }

        public IEnumerable<Entities.VoteSystem> All()
        {
            return _voteSystemRepository.GetAll();
        }

        public IEnumerable<Entities.VoteSystem> GetAllAvailableVoteSystemsForUserByUserId(Guid userId)
        {
            // TODO fix it later ?? fix what ??
            return _voteSystemRepository
                                    .GetAllWithParticipants()
                                    .Where(x =>
                                            x.StarDateTime <= DateTime.Now &&
                                            DateTime.Now <= x.EndDateTime &&
                                            x.Participants.Any(y =>
                                                                y.VoteSystemUserId == userId &&
                                                                y.IsVoted == false));
        }

        public Entities.VoteSystem GetById(int voteSystemId)
        {
            return _voteSystemRepository.GetById(voteSystemId);
        }
    }
}
