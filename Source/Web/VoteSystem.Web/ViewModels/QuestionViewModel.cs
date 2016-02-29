namespace VoteSystem.Web.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class QuestionViewModel : IMapFrom<Question>, IMapTo<Question>
    {
        public QuestionViewModel()
        {
            this.QuestionAnswers = new List<QuestionAnswerViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Question Name")]
        [MinLength(2, ErrorMessage = "The question name can not be less than 2 symbols.")]
        [MaxLength(200, ErrorMessage = "The question name can not be greater than 200 symbols.")]
        public string QuestionName { get; set; }

        public int RateSystemId { get; set; }

        public IList<QuestionAnswerViewModel> QuestionAnswers { get; set; }
    }
}