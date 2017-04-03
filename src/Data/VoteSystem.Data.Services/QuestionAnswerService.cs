using VoteSystem.Data.Contracts;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly IRepository<QuestionAnswer> questionAndAnswers;

        public QuestionAnswerService(IRepository<QuestionAnswer> questionAndAnswers)
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
