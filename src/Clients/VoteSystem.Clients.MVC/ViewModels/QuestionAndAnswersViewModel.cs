using System.Collections.Generic;

namespace VoteSystem.Clients.MVC.ViewModels
{
    // TODO seperate all view models in folders
    
    public class QuestionAndAnswersViewModel
    {
        public QuestionAndAnswersViewModel()
        {
            this.Questions = new List<QuestionViewModel>();
        }

        public int RateSystemId { get; set; }

        public IList<QuestionViewModel> Questions { get; set; }
    }
}