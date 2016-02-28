namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using VoteSystem.Data.Models;
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
    }
}