using System.Collections.Generic;

using VoteSystem.Data.Entities;

namespace VotySystem.Data.DTO
{
    public class VoteSystemWithQuestionsDto
    {
        public VoteSystemWithQuestionsDto()
        {
            Questions = new List<Question>();
        }

        public IList<Question> Questions { get; set; }
    }
}
