using System.Collections.Generic;
using VoteSystem.Clients.MVC.Areas.Administration.ViewModels.Question;
using VoteSystem.Clients.MVC.Infrastructure.Mapping.Contracts;
using VotySystem.Data.DTO;

namespace VoteSystem.Clients.MVC.Areas.Administration.ViewModels.VoteSystem
{
    public class VoteSystemWithQuestionsViewModel : IMapTo<VoteSystemWithQuestionsDto>
    {
        public VoteSystemWithQuestionsViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }

        public IList<QuestionViewModel> Questions { get; set; }
    }
}