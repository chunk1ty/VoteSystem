using System.Collections.Generic;
using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IQuestionService
    {
        void Add(Question question);

        void Delete(Question question);

        IEnumerable<Question> GetAllQuestions(string voteSystemId);

        IEnumerable<Question> GetUsersAnswers(int rateSystemId);
    }
}
