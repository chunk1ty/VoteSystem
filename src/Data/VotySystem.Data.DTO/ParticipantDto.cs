using System.Collections.Generic;

namespace VotySystem.Data.DTO
{
    public class ParticipantDto
    {
        public int Id { get; set; }

        public bool IsVoted { get; set; }

        public ICollection<ParticipantAnswerDto> ParticipantAnswers { get; set; }

        public string VoteSystemUserId { get; set; }
        public virtual VoteSystemUserDto VoteSystemUser { get; set; }

        public int RateSystemId { get; set; }
        public virtual SurveyDto RateSystem { get; set; }
    }
}
