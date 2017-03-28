namespace VoteSystem.Services.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Services.Web.Contracts;

    public class QuestionService : IQuestionService
    {
        private readonly IDbGenericRepository<Question> questions;
        private readonly IIdentifierProvider identifierProvider;

        public QuestionService(IDbGenericRepository<Question> questions, IIdentifierProvider identifierProvider)
        {
            this.questions = questions;
            this.identifierProvider = identifierProvider;
        }

        public void Add(Question question)
        {
            this.questions.Add(question);
        }

        public void Delete(Question question)
        {
            this.questions.Delete(question);
        }

        public IQueryable<Question> GetAllQuestions(string rateSystemId)
        {
            var rateSystemIntId = this.identifierProvider.DecodeId(rateSystemId);

            // TODO x.IsDeleted ? if i use deletable entity
            return this.questions
                            .All()
                            .Where(x => x.RateSystemId == rateSystemIntId);
        }

        // TODO this method is use only for administration because rateSystemId is not encode/decode. Encode/decode it in the future.
        public IQueryable<Question> GetAllQuestions(int rateSystemId)
        {
            return this.questions
                            .All()
                            .Where(x => x.RateSystemId == rateSystemId);
        }

        public IQueryable<Question> GetUsersAnswers(int rateSystemId)
        {
            return this.questions
                .All()
                .Where(x => x.RateSystemId == rateSystemId)
                .Include(x => x.QuestionAnswers
                                .Select(y => y.ParticipantAnswers.Count));
        }

        public void SaveChanges()
        {
            this.questions.SaveChanges();
        }
    }
}
