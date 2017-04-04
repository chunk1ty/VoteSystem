using VoteSystem.Data.Contracts;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Data.Services
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly IQuestionAnswerRepository questionAnswerRepository;

        public QuestionAnswerService(IQuestionAnswerRepository questionAndAnswers)
        {
            // TODO add mapping logic
            //this.questionAnswerRepository = questionAnswerRepository;
        }

        public void Add(QuestionAnswerDto questionAndAnswers)
        {
            // TODO add mapping logic
            //this.questionAnswerRepository.Add(questionAndAnswers);
        }
    }
}
