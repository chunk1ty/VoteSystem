using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VoteSystem.Clients.MVC.Infrastructure.Mapping.Contracts;
using VoteSystem.Services.Web;
using VoteSystem.Services.Web.Contracts;

namespace VoteSystem.Clients.MVC.Areas.Administration.ViewModels.VoteSystem
{
    public class VoteSystemViewModel : IMapFrom<Data.Entities.VoteSystem>, IMapTo<Data.Entities.VoteSystem>
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
        public string Name { get; set; }

        [Required]
        [DisplayName("Начална дата")]
        [DataType(DataType.DateTime)]
        public DateTime StarDateTime { get; set; }

        [Required]
        [DisplayName("Крайна дата")]
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }
    }
}