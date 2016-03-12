namespace VoteSystem.Web.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class QuestionAnswerViewModel : IMapFrom<QuestionAnswer>, IMapTo<QuestionAnswer>
    {
        public int Id { get; set; }

        // TODO required broke logic when user fill rate system. Create separate VM for filling.
        //[Required]
        [MinLength(2, ErrorMessage = "The answer can not be less than 2 symbols.")]
        [MaxLength(100, ErrorMessage = "The answer can not be greater than 100 symbols.")]
        [DisplayName("Answer")]
        public string QuestionAnswerName { get; set; }
        
        public bool IsChecked { get; set; }

        public int QuestionId { get; set; }

        public IList<ParticipantAnswerViewModel> UserAnswers { get; set; }
    }
}