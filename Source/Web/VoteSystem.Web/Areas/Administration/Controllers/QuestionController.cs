namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using VoteSystem.Common;
    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Web.ViewModels;

    public class QuestionController : AdministrationController
    {
        private IQuestionService questions;

        public QuestionController(IQuestionService questions)
        {
            this.questions = questions;
        }

        [HttpGet]
        public ActionResult Create()
        {
            QuestionAndAnswersViewModel questionsAndAnswers = new QuestionAndAnswersViewModel();

            return this.View(questionsAndAnswers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionAndAnswersViewModel model)
        {
            var request = this.Request;

            if (!ModelState.IsValid)
            {
                return this.View();
            }
          
            return this.RedirectToAction<QuestionController>(c => c.Create());
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
    }
}