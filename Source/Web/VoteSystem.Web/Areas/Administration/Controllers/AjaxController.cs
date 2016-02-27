namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using VoteSystem.Common;
    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Web.ViewModels;

    public class AjaxController : AdministrationController
    {
        private readonly IRateSystemService rateSystems;

        public AjaxController(IRateSystemService rateSystems)
        {
            this.rateSystems = rateSystems;
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
            this.rateSystems.Delete(rateSystemId);

            return this.Content("DELETED");
        }
    }
}