namespace VoteSystem.Services.Data
{
    using System.Data.Entity;
    using System.Linq;

    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;

    public class QuestionService : IQuestionService
    {
        private readonly IDeletableEntityRepository<Question> questions;

        public QuestionService(IDeletableEntityRepository<Question> questions)
        {
            this.questions = questions;
        }

        public void Add(Question question)
        {
            this.questions.Add(question);
        }

        public void SaveChanges()
        {
            this.questions.SaveChanges();
        }

        public IQueryable<Question> GetAllQuestions(int rateSystemId)
        {
            // TODO x.IsDeleted ? if i use deletable entity
            return this.questions
                            .All()
                            .Where(x => x.RateSystemId == rateSystemId);
        }

        public IQueryable<Question> GetUsersAnswers(int rateSystemId)
        {
            return this.questions
                .All()
                .Include(x => x.QuestionAnswers
                                .Select(y => y.UserAnswers));
        }
    }
}
