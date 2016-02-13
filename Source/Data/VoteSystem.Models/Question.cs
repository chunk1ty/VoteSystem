namespace VoteSystem.Data.Models
{
    using Common.Models;

    public class Question : BaseModel<int>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int RateSystemId { get; set; }

        public virtual RateSystem RateSystem { get; set; }
    }
}
