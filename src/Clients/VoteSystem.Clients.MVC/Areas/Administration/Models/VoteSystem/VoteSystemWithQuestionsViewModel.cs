using System.Collections.Generic;

using VoteSystem.Clients.MVC.Areas.Administration.Models.Question;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VotySystem.Data.DTO;

namespace VoteSystem.Clients.MVC.Areas.Administration.Models.VoteSystem
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