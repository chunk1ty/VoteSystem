namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using VoteSystem.Common;
    using VoteSystem.Web.ViewModels;

    public class AjaxController : AdministrationController
    {
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
    }
}