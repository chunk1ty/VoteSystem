using System.Data.Entity;
using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.DtoModels;
using VoteSystem.Data.Models;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Services.Contracts;
using VoteSystem.Services.Web.Contracts;

namespace VoteSystem.Data.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IEntityFrameworkRepository<Question> questions;
        private readonly IIdentifierProvider identifierProvider;

        public QuestionService(IEntityFrameworkRepository<Question> questions, IIdentifierProvider identifierProvider)
        {
            this.questions = questions;
            this.identifierProvider = identifierProvider;
        }

        public void Add(QuestionDto question)
        {
            // TODO add mapping logic
            //this.questions.Add(question);
        }

        public void Delete(QuestionDto question)
        {
            // TODO add mapping logic
            //this.questions.Delete(question);
        }

        public IQueryable<QuestionDto> GetAllQuestions(string rateSystemId)
        {
            // TODO add mapping logic
            var rateSystemIntId = this.identifierProvider.DecodeId(rateSystemId);

            // TODO x.IsDeleted ? if i use deletable entity
            //return this.questions
            //                .All()
            //                .Where(x => x.RateSystemId == rateSystemIntId);
            return null;
        }

        // TODO this method is use only for administration because rateSystemId is not encode/decode. Encode/decode it in the future.
        public IQueryable<QuestionDto> GetAllQuestions(int rateSystemId)
        {
            // TODO add mapping logic
            //return this.questions
            //                .All()
            //                .Where(x => x.RateSystemId == rateSystemId);
            return null;
        }

        public IQueryable<QuestionDto> GetUsersAnswers(int rateSystemId)
        {
            // TODO add mapping logic
            //return this.questions
            //    .All()
            //    .Where(x => x.RateSystemId == rateSystemId)
            //    .Include(x => x.QuestionAnswers
            //                    .Select(y => y.ParticipantAnswers.Count));
            return null;
        }
    }
}
