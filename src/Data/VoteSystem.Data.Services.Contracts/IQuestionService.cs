using System.Collections.Generic;

using VoteSystem.Data.Entities;
using VotySystem.Data.DTO;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IQuestionService
    {
        void Add(Question question);

        void AddQuestions(VoteSystemWithQuestionsDto voteSystem);

        void UpdateQuestions(VoteSystemWithQuestionsDto voteSystem);

        void Delete(Question question);

        IEnumerable<Question> GetAllQuestions(string voteSystemId);

        IEnumerable<Question> GetQuestionsWithAnswersByVoteSystemId(int voteSystemId);

        IEnumerable<QuestionResultDto> GetQuestionResultByVoteSystemId(int rateSystemId);
    }
}
