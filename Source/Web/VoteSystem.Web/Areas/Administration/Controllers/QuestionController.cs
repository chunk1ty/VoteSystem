namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using Data.Models;
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
        public ActionResult Create(int rateSystemId)
        {
            ViewBag.RateSystemId = rateSystemId;
            return this.View(new QuestionAndAnswersViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionAndAnswersViewModel model, int rateSystemId)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            foreach (var question in model.Questions)
            {
                var questionDbModel = this.Mapper.Map<Question>(question);
                // TODO think better way with automapper (rateSystemId)
                questionDbModel.RateSystemId = rateSystemId;

                this.questions.Add(questionDbModel);
            }

            this.questions.SaveChanges();

            return this.RedirectToAction<QuestionController>(c => c.Create(1));
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