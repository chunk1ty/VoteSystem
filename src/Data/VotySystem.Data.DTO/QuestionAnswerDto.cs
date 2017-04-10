﻿using System.Collections.Generic;

namespace VotySystem.Data.DTO
{
    public class QuestionAnswerDto
    {
        public int Id { get; set; }

        public string QuestionAnswerName { get; set; }

        public int QuestionId { get; set; }
        public virtual QuestionDto Question { get; set; }

        public ICollection<ParticipantAnswerDto> ParticipantAnswers { get; set; }
    }
}