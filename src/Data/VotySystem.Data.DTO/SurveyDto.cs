using System;
using System.Collections.Generic;

namespace VotySystem.Data.DTO
{
    public class SurveyDto
    {
        public int Id { get; set; }
       
        public string Name { get; set; }

        public DateTime StarDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public ICollection<QuestionDto> Questions { get; set; }

        public ICollection<ParticipantDto> Participants { get; set; }
    }
}
