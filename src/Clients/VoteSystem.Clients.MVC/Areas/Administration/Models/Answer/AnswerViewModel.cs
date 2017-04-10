using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Data.Entities;

namespace VoteSystem.Clients.MVC.Areas.Administration.Models.Answer
{
    public class AnswerViewModel : IMapFrom<QuestionAnswer>, IMapTo<QuestionAnswer>
    {
        public int Id { get; set; }

        // TODO required broke logic when user fill vote system. Create separate VM for filling.
        //[Required]
        [MinLength(2, ErrorMessage = "Отговорът не може да е по кратък от 2 символа")]
        [MaxLength(100, ErrorMessage = "Отговорът не може да е по голям от 100 символа")]
        [DisplayName("Отговор")]
        public string Name { get; set; }
        
        // TODO these properties should be part of another VM
        //public bool IsChecked { get; set; }
        //public IList<ParticipantAnswerViewModel> UserAnswers { get; set; }
    }
}