namespace VoteSystem.Web.ViewModels
{
    // TODO seperate all view models in folders
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