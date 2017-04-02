using VoteSystem.Data.Contracts;
using VoteSystem.Data.DtoModels;
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
            // TODO add mapping logic
//            /this.questionAndAnswers = questionAndAnswers;
        }

        public void Add(QuestionAnswerDto questionAndAnswers)
        {
            // TODO add mapping logic
            //this.questionAndAnswers.Add(questionAndAnswers);
        }
    }
}
