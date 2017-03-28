using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VoteSystem.Data.Models;
using VoteSystem.Services.Web;
using VoteSystem.Services.Web.Contracts;
using VoteSystem.Web.Infrastructure.Mapping;

namespace VoteSystem.Clients.MVC.ViewModels
{
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
        [DisplayName("Име")]
        [MinLength(5, ErrorMessage = "Името на системата не може да бъде по-малко от 5 символа.")]
        [MaxLength(100, ErrorMessage = "Името на системата не може да бъде по-голямо от 100 символа.")]
        public string RateSystemName { get; set; }

        [Required]
        [DisplayName("Начална дата")]
        [DataType(DataType.DateTime)]
        public DateTime StarDateTime { get; set; }

        [Required]
        [DisplayName("Крайна дата")]
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}