using System.Collections.Generic;
using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;
using VoteSystem.Services.Web.Contracts;

namespace VoteSystem.Data.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IIdentifierProvider _identifierProvider;
        private readonly IVoteSystemEfDbContextSaveChanges _dbContextSaveChanges;

        public QuestionService(IQuestionRepository questionRepository, IIdentifierProvider identifierProvider, IVoteSystemEfDbContextSaveChanges dbContextSaveChanges)
        {
            _questionRepository = questionRepository;
            _identifierProvider = identifierProvider;
            _dbContextSaveChanges = dbContextSaveChanges;
        }

        public void Add(Question question)
        {
            _questionRepository.Add(question);

            _dbContextSaveChanges.SaveChanges();
        }

        public void Delete(Question question)
        {
            // TODO add mapping logic
            _questionRepository.Delete(question);

            _dbContextSaveChanges.SaveChanges();
        }

        public IEnumerable<Question> GetAllQuestions(string voteSystemId)
        {
            // TODO add mapping logic
            var decodedVoteSystemId = this._identifierProvider.DecodeId(voteSystemId);
           
            return _questionRepository
                            .GetAllQuestionsWithAnswers()
                            .Where(x => x.VoteSystemId == decodedVoteSystemId && !x.IsDeleted);
        }

        public IEnumerable<Question> GetQuestionsWithAnswersByVoteSystemId(int voteSystemId)
        {
            // TODO: ASK in memory ?? isn't it to slow instead of sql query ??
            return _questionRepository
                                    .GetAllQuestionsWithAnswers()
                                    .Where(x => x.VoteSystemId == voteSystemId && !x.IsDeleted);
        }

        public IEnumerable<Question> GetUsersAnswers(int voteSystemId)
        {
            // TODO add mapping logic

            return _questionRepository.GetUsersAnswersByVoteSystemId(voteSystemId);
        }
    }
}
