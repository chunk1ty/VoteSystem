using System.Web.Mvc;

using VoteSystem.Clients.MVC.ViewModels;
using VoteSystem.Common.Constants;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class AjaxController : AdminController
    {
        private readonly IVoteSystemService voteSystems;

        public AjaxController(IVoteSystemService voteSystems)
        {
            this.voteSystems = voteSystems;
        }

        [HttpGet]
        public ActionResult MoreQuestions()
        {
            return this.PartialView(PartialViewConstants.QuestionPartial, new QuestionViewModel());
        }

        // TODO extract in another controller QuestionAnswerController
        [HttpGet]
        public ActionResult MoreAnswers(string containerPrefix)
        {
            ViewBag.ContainerPrefix = containerPrefix;

            return this.PartialView(PartialViewConstants.QuestionAnswerPartial, new QuestionAnswerViewModel());
        }

        [HttpPost]
        public ActionResult DeleteRateSystem(int rateSystemId)
        {
            this.voteSystems.Delete(rateSystemId);

            return this.Content("DELETED");
        }
    }
}