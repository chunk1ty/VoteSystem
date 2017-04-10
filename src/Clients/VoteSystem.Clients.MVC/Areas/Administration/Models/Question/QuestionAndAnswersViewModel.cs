using System.Collections.Generic;

using VoteSystem.Clients.MVC.ViewModels;

namespace VoteSystem.Clients.MVC.Areas.Administration.Models.Question
{
    public class QuestionAndAnswersViewModel
    {
        public QuestionAndAnswersViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }

        public int VoteSystemId { get; set; }

        public IList<QuestionViewModel> Questions { get; set; }
    }
}