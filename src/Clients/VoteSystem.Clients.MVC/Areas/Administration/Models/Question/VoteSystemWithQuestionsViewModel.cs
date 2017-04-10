using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VoteSystem.Clients.MVC.Areas.Administration.Models.Question
{
    public class VoteSystemWithQuestionsViewModel
    {
        public VoteSystemWithQuestionsViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }

        [Required]
        public int VoteSystemId { get; set; }

        public IList<QuestionViewModel> Questions { get; set; }
    }
}