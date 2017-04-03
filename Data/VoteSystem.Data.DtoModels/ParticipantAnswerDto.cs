namespace VoteSystem.Data.DTO
{
    public class ParticipantAnswerDto
    {
        public int Id { get; set; }

        public string ParticipantId { get; set; }
        public virtual ParticipantDto Participant { get; set; }

        public int QuestionAnswerId { get; set; }
        public virtual QuestionDto QuestionAnswer { get; set; }
    }
}
