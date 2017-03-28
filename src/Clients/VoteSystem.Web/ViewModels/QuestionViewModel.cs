using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VoteSystem.Data.Models;
using VoteSystem.Web.Infrastructure.Mapping;

namespace VoteSystem.Clients.MVC.ViewModels
{
    public class QuestionViewModel : IMapFrom<Question>, IMapTo<Question>
    {
        public QuestionViewModel()
        {
            this.QuestionAnswers = new List<QuestionAnswerViewModel>();
        }

        public int Id { get; set; }
        
        [DisplayName("Име на въпроса")]
        [Required(ErrorMessage = "Името на въпросът е задължително.")]
        [MinLength(2, ErrorMessage = "Въпросът не може да е по-малък от 2 символа.")]
        [MaxLength(200, ErrorMessage = "Въпросът не може да е по-голям от 100 символа.")]
        public string QuestionName { get; set; }

        [Required]
        [DisplayName("Бихте ли желали да има повече от един отговор?")]
        public bool HasMultipleAnswers { get; set; }

        public int RateSystemId { get; set; }

        public IList<QuestionAnswerViewModel> QuestionAnswers { get; set; }
    }
}