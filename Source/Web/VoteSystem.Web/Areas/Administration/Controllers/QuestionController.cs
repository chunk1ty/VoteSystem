namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using Data.Models;
    using Services.Data.Contracts;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using ViewModels;
    using Web.Controllers;
    using VoteSystem.Web.Infrastructure.Mapping;
    using System.Linq;
    using Common;

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

            //var dbModel = this.Mapper.Map<Question>(model);
            //this.questions.Add(dbModel);

            //return this.RedirectToAction<QuestionController>(c => c.Create(model.RateSystemId));
            return this.RedirectToAction<QuestionController>(c => c.Create());
        }

        [HttpGet]
        public ActionResult MoreQuestions()
        {
            return this.PartialView(PartialViewConstants.QuestionPartial, new QuestionViewModel());
        }

        [HttpGet]
        public ActionResult MoreAnswers(string containerPrefix)
        {          
            ViewData["ContainerPrefix"] = containerPrefix;

            return this.PartialView(PartialViewConstants.QuestionAnswerPartial, new QuestionAnswerViewModel());
        }
    }
}