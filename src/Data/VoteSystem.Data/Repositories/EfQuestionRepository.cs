using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.Ef.Contracts;
using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Ef.Repositories
{
    public class EfQuestionRepository : IQuestionRepository
    {
        private readonly IVoteSystemDbContext _voteSystemDbContext;

        public EfQuestionRepository(IVoteSystemDbContext voteSystemDbContext)
        {
            _voteSystemDbContext = voteSystemDbContext;
        }

        public void Add(Question question)
        {
            var entry = _voteSystemDbContext.Entry(question);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                _voteSystemDbContext.Questions.Add(question);
            }
        }

        public void Delete(Question question)
        {
            var entry = _voteSystemDbContext.Entry(question);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                _voteSystemDbContext.Set<Question>().Attach(question);
                _voteSystemDbContext.Set<Question>().Remove(question);
            }
        }

        public IEnumerable<Question> All()
        {
            return _voteSystemDbContext.Questions;
        }

        public IEnumerable<Question> GetUsersAnswersByVoteSystemId(int voteSystemId)
        {
            return _voteSystemDbContext.Questions
                                    .Where(x => x.VoteSystemId == voteSystemId)
                                    .Include(x => x.QuestionAnswers
                                                    .Select(y => y.ParticipantAnswers.Count));
        }
    }
}
