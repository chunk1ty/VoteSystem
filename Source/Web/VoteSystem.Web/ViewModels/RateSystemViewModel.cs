namespace VoteSystem.Web.ViewModels
{  
    using System;
    using System.Collections.Generic;

    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class RateSystemViewModel : IMapFrom<RateSystem>, IMapTo<RateSystem>
    {
        public int Id { get; set; }

        public string RateSystemName { get; set; }
       
        public DateTime? StarDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}