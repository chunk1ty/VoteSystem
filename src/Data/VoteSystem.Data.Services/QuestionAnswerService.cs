using VoteSystem.Data.Contracts;
using VoteSystem.Data.Models;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly IEntityFrameworkRepository<QuestionAnswer> questionAndAnswers;

        public QuestionAnswerService(IEntityFrameworkRepository<QuestionAnswer> questionAndAnswers)
        {
            this.questionAndAnswers = questionAndAnswers;
        }

        public void Add(QuestionAnswer questionAndAnswers)
        {
            this.questionAndAnswers.Add(questionAndAnswers);
        }
    }
}
