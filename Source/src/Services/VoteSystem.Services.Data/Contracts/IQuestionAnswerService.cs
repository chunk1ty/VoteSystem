namespace VoteSystem.Services.Data.Contracts
{
    using VoteSystem.Data.Models;

    public interface IQuestionAnswerService
    {
        void Add(QuestionAnswer questionAndAnswers);

        void SaveChanges();
    }
}
