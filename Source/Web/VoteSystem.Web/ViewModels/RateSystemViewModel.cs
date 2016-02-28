namespace VoteSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class RateSystemViewModel : IMapFrom<RateSystem>, IMapTo<RateSystem>
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string RateSystemName { get; set; }

        [Required]
        [DisplayName("Start Date")]
        [DataType(DataType.DateTime)]
        public DateTime StarDateTime { get; set; }

        [Required]
        [DisplayName("End Date")]
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}