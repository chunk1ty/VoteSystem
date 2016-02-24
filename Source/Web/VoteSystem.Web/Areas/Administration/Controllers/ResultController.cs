namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Web.Infrastructure.Mapping;
    using VoteSystem.Web.ViewModels;

    public class ResultController : AdministrationController
    {
        private IQuestionService questions;

        public ResultController(IQuestionService questions)
        {
            this.questions = questions;
        }

        public ActionResult Index(int rateSystemId)
        {
            var result = this.questions
                .GetUsersAnswers(rateSystemId)
                .To<QuestionViewModel>()
                .ToList();

            return this.View(result);
        }
    }
}