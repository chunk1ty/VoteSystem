using System.Collections.Generic;

using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Contracts
{
    public interface IQuestionRepository
    {
        void Add(Question question);

        void Delete(Question question);

        IEnumerable<Question> All();

        IEnumerable<Question> GetUsersAnswersByVoteSystemId(int voteSystemId);
    }
}
