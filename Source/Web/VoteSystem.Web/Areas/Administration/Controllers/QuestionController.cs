namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Web.Infrastructure.Mapping;
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
            return this.View(new QuestionAndAnswersViewModel() { RateSystemId = rateSystemId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionAndAnswersViewModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return this.View(model);
            }

            if (model.Questions.Count() == 0)
            {
                this.ModelState.AddModelError(string.Empty, "You have to add at least one question!");
                return this.View(model);
            }

            foreach (var question in model.Questions)
            {
                var questionDbModel = this.Mapper.Map<Question>(question);               
                questionDbModel.RateSystemId = model.RateSystemId;

                this.questions.Add(questionDbModel);
            }

            this.questions.SaveChanges();

            return this.RedirectToAction<RateSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int rateSystemId)
        {
            var questions = this.questions
                .GetAllQuestions(rateSystemId)
                .To<QuestionViewModel>()
                .ToList();

            return this.View(new QuestionAndAnswersViewModel() { Questions = questions, RateSystemId = rateSystemId });
        }

        // TODO optimize method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionAndAnswersViewModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return this.View(model);
            }

            if (model.Questions.Count() == 0)
            {
                this.ModelState.AddModelError(string.Empty, "You have to add at least one question!");
                return this.View(model);
            }

            var allExistingQuestions = this.questions.GetAllQuestions(model.RateSystemId);

            foreach (var existingQuestion in allExistingQuestions)
            {
                this.questions.Delete(existingQuestion);
            }

            this.questions.SaveChanges();

            foreach (var question in model.Questions)
            {
                var questionDbModel = this.Mapper.Map<Question>(question);
                questionDbModel.RateSystemId = model.RateSystemId;

                this.questions.Add(questionDbModel);
            }

            this.questions.SaveChanges();

            return this.RedirectToAction<RateSystemController>(c => c.Index());
        }
        
        public ActionResult Preview(int rateSystemId)
        {
            var questionsAsVM = this.questions
                .GetAllQuestions(rateSystemId)
                .To<QuestionViewModel>()
                .ToList();

            return this.View(questionsAsVM);
        }
    }
}