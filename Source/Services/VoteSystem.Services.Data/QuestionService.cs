namespace VoteSystem.Services.Data
{
    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;

    public class QuestionService : IQuestionService
    {
        private readonly IDbGenericRepository<Question> questions;

        public QuestionService(IDbGenericRepository<Question> questions)
        {
            this.questions = questions;
        }
    }
}
