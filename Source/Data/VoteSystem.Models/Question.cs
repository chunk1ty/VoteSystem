namespace VoteSystem.Data.Models
{
    using Common.Models;

    public class Question : BaseModel<int>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int VoteSystemId { get; set; }

        public virtual VoteSystem VoteSystem { get; set; }
    }
}
