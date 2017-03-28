using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VoteSystem.Data.Models;
using VoteSystem.Web.Infrastructure.Mapping;

namespace VoteSystem.Clients.MVC.ViewModels
{
    public class QuestionAnswerViewModel : IMapFrom<QuestionAnswer>, IMapTo<QuestionAnswer>
    {
        public int Id { get; set; }

        // TODO required broke logic when user fill rate system. Create separate VM for filling.
        //[Required]
        [MinLength(2, ErrorMessage = "Отговорът не може да е по кратък от 2 символа")]
        [MaxLength(100, ErrorMessage = "Отговорът не може да е по голям от 100 символа")]
        [DisplayName("Отговор")]
        public string QuestionAnswerName { get; set; }
        
        public bool IsChecked { get; set; }

        public int QuestionId { get; set; }

        public IList<ParticipantAnswerViewModel> UserAnswers { get; set; }
    }
}