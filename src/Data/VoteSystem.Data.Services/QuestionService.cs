using System.Collections.Generic;
using System.Linq;

using VoteSystem.Data.Contracts;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;
using VoteSystem.Services.Web.Contracts;
using VotySystem.Data.DTO;

namespace VoteSystem.Data.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IIdentifierProvider _identifierProvider;
        private readonly IVoteSystemEfDbContextSaveChanges _dbContextSaveChanges;

        public QuestionService(
            IQuestionRepository questionRepository, 
            IIdentifierProvider identifierProvider, 
            IVoteSystemEfDbContextSaveChanges dbContextSaveChanges)
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

        // TODO bulk insert
        public void AddQuestions(VoteSystemWithQuestionsDto voteSystem)
        {
            foreach (var question in voteSystem.Questions)
            {
                _questionRepository.Add(question);
            }

            _dbContextSaveChanges.SaveChanges();
        }

        public void UpdateQuestions(VoteSystemWithQuestionsDto voteSystem)
        {
            var voteSystemId = voteSystem.Questions.FirstOrDefault().VoteSystemId;
            var allExistingQuestions = GetQuestionsWithAnswersByVoteSystemId(voteSystemId);

            foreach (var question in allExistingQuestions)
            {
                _questionRepository.Delete(question);
            }

            foreach (var question in voteSystem.Questions)
            {
                _questionRepository.Add(question);
            }

            _dbContextSaveChanges.SaveChanges();
        }

        public void Delete(Question question)
        {
            _questionRepository.Delete(question);

            _dbContextSaveChanges.SaveChanges();
        }

        public IEnumerable<Question> GetAllQuestions(string voteSystemId)
        {
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

        public IEnumerable<QuestionResultDto> GetQuestionResultByVoteSystemId(int voteSystemId)
        {
            var result = _questionRepository
                                    .GetUsersAnswersByVoteSystemId(voteSystemId)
                                    .Select(x => new QuestionResultDto()
                                    {
                                        Name = x.Name,
                                        HasMultipleAnswers = x.HasMultipleAnswers,
                                        Answers = x.Answers.Select(
                                               y => new AnswerResultDto()
                                               {
                                                   Name = y.Name,
                                                   Count = y.ParticipantAnswers.Count
                                               })
                                    });

            return result;
        }
    }
}
