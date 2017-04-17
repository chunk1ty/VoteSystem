using System.Collections.Generic;
using VoteSystem.Data.Entities;
using VotySystem.Data.DTO;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IQuestionService
    {
        void AddRange(IList<Question> questions);

        void UpdateRange(IList<Question> questions);

        IEnumerable<Question> GetQuestionsWithAnswersByEncodedVoteSystemId(string voteSystemId);

        // TODO use encoded votesystemId
        IEnumerable<Question> GetQuestionsWithAnswersByVoteSystemId(int voteSystemId);

        IEnumerable<QuestionResultDto> GetQuestionResultByVoteSystemId(int voteSystemId);
    }
}
