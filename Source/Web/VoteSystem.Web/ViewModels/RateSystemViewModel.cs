namespace VoteSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using VoteSystem.Data.Models;
    using VoteSystem.Services.Web;
    using VoteSystem.Services.Web.Contracts;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class RateSystemViewModel : IMapFrom<RateSystem>, IMapTo<RateSystem>
    {
        public int Id { get; set; }

        public string EncodedId
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return identifier.EncodeId(this.Id);
            }
        }

        [Required]
        [DisplayName("Name")]
        [MinLength(5, ErrorMessage = "The rate system name can not be less than 5 symbols.")]
        [MaxLength(100, ErrorMessage = "The rate system name can not be greater than 100 symbols.")]
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