using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;
using VoteSystem.Services.Web.Contracts;

namespace VoteSystem.Data.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IIdentifierProvider identifierProvider;

        public QuestionService(IQuestionRepository questionRepository, IIdentifierProvider identifierProvider)
        {
            this.questionRepository = questionRepository;
            this.identifierProvider = identifierProvider;
        }

        public void Add(QuestionDto question)
        {
            // TODO add mapping logic
            //this.questionRepository.Add(question);
        }

        public void Delete(QuestionDto question)
        {
            // TODO add mapping logic
            //this.questionRepository.Delete(question);
        }

        public IQueryable<QuestionDto> GetAllQuestions(string rateSystemId)
        {
            // TODO add mapping logic
            var rateSystemIntId = this.identifierProvider.DecodeId(rateSystemId);

            // TODO x.IsDeleted ? if i use deletable entity
            //return this.questionRepository
            //                .All()
            //                .Where(x => x.RateSystemId == rateSystemIntId);
            return null;
        }

        // TODO this method is use only for administration because rateSystemId is not encode/decode. Encode/decode it in the future.
        public IQueryable<QuestionDto> GetAllQuestions(int rateSystemId)
        {
            // TODO add mapping logic
            //return this.questionRepository
            //                .All()
            //                .Where(x => x.RateSystemId == rateSystemId);
            return null;
        }

        public IQueryable<QuestionDto> GetUsersAnswers(int rateSystemId)
        {
            // TODO add mapping logic
            // remove Ef dependency (move Include!!)
            //return this.questionRepository
            //    .All()
            //    .Where(x => x.RateSystemId == rateSystemId)
            //    .Include(x => x.QuestionAnswers
            //                    .Select(y => y.ParticipantAnswers.Count));
            return null;
        }
    }
}
