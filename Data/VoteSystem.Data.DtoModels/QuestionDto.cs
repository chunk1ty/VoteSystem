using System.Collections.Generic;

namespace VoteSystem.Data.DTO
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public bool HasMultipleAnswers { get; set; }

        public int RateSystemId { get; set; }
        public virtual SurveyDto Survey { get; set; }

        public ICollection<QuestionAnswerDto> QuestionAnswers { get; set; }
    }
}
