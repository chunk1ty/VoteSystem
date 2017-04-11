using VoteSystem.Data.Contracts;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly IQuestionAnswerRepository _questionAnswerRepository;
        private readonly IVoteSystemEfDbContextSaveChanges _dbContextSaveChanges;

        public QuestionAnswerService(IQuestionAnswerRepository questionAnswerRepository, IVoteSystemEfDbContextSaveChanges dbContextSaveChanges)
        {
            _questionAnswerRepository = questionAnswerRepository;
            _dbContextSaveChanges = dbContextSaveChanges;
        }

        public void Add(Answer questionAndAnswers)
        {
            // TODO add mapping logic
            _questionAnswerRepository.Add(questionAndAnswers);

            _dbContextSaveChanges.SaveChanges();
        }
    }
}
