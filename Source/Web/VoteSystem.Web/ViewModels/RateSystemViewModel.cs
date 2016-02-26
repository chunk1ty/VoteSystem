namespace VoteSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;    
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class RateSystemViewModel : IMapFrom<RateSystem>, IMapTo<RateSystem>
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string RateSystemName { get; set; }

        [DisplayName("Start Date")]
        public DateTime StarDateTime { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDateTime { get; set; }

        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}