namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Web.ViewModels;
    using VoteSystem.Web.Infrastructure.Mapping;
    using System.Linq;
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
                return this.View(model);
            }

            foreach (var question in model.Questions)
            {
                var questionDbModel = this.Mapper.Map<Question>(question);               
                questionDbModel.RateSystemId = rateSystemId;

                this.questions.Add(questionDbModel);
            }

            this.questions.SaveChanges();

            return this.RedirectToAction<RateSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int rateSystemId)
        {
            ViewBag.RateSystemId = rateSystemId;
            var questions = this.questions
                .GetAllQuestions(rateSystemId)
                .To<QuestionViewModel>()
                .ToList();

            return this.View(new QuestionAndAnswersViewModel() { Questions = questions });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionAndAnswersViewModel model, int rateSystemId)
        {
            if (!ModelState.IsValid || model == null)
            {
                return this.View(model);
            }

            var allExistingQuestions = this.questions.GetAllQuestions(rateSystemId);

            foreach (var existingQuestion in allExistingQuestions)
            {
                this.questions.Delete(existingQuestion);
            }

            this.questions.SaveChanges();

            foreach (var question in model.Questions)
            {   
                var questionDbModel = this.Mapper.Map<Question>(question);
                questionDbModel.RateSystemId = rateSystemId;
                
                this.questions.Add(questionDbModel);
            }

            this.questions.SaveChanges();

            return this.RedirectToAction<RateSystemController>(c => c.Index());
        }
    }
}