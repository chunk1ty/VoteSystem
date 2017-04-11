using System.Collections.Generic;

namespace VotySystem.Data.DTO
{
    public class QuestionResultDto
    {
        public QuestionResultDto()
        {
            Answers = new HashSet<AnswerResultDto>();
        }

        public string Name { get; set; }

        public bool HasMultipleAnswers { get; set; }

        public IEnumerable<AnswerResultDto> Answers { get; set; }
    }
}