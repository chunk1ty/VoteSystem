namespace VoteSystem.Web.ViewModels
{
    using System.Collections.Generic;

    public class QuestionAndAnswersViewModel
    {
        public QuestionAndAnswersViewModel()
        {
            this.Questions = new HashSet<QuestionViewModel>();
        }

        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}