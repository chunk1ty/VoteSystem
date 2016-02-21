namespace VoteSystem.Services.Data
{
    using System;
    using VoteSystem.Data.Common;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;

    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly IDbGenericRepository<QuestionAnswers> questionAndAnswers;

        public QuestionAnswerService(IDbGenericRepository<QuestionAnswers> questionAndAnswers)
        {
            this.questionAndAnswers = questionAndAnswers;
        }

        public void Add(QuestionAnswers questionAndAnswers)
        {
            this.questionAndAnswers.Add(questionAndAnswers);
        }

        public void SaveChanges()
        {
            this.questionAndAnswers.SaveChanges();
        }
    
    }
}
