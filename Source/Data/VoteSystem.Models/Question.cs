namespace VoteSystem.Data.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int VoteSystemId { get; set; }

        public virtual VoteSystem VoteSystem { get; set; }
    }
}
