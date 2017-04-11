using VoteSystem.Data.Contracts;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IVoteSystemEfDbContextSaveChanges _dbContextSaveChanges;

        public AnswerService(IAnswerRepository answerRepository, IVoteSystemEfDbContextSaveChanges dbContextSaveChanges)
        {
            _answerRepository = answerRepository;
            _dbContextSaveChanges = dbContextSaveChanges;
        }

        public void Add(Answer questionAndAnswers)
        {
            // TODO add mapping logic
            _answerRepository.Add(questionAndAnswers);

            _dbContextSaveChanges.SaveChanges();
        }
    }
}
