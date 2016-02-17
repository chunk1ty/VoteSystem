namespace VoteSystem.Services.Data.Contracts
{
    using VoteSystem.Data.Models;

    public interface IQuestionService
    {
        void Add(Question question);
    }
}
