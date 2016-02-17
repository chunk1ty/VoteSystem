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
    using Infrastructure.Constants;
    public class QuestionController : AdministrationController
    {
        private IQuestionService questions;

        public QuestionController(IQuestionService questions)
        {
            this.questions = questions;
        }

        [HttpGet]
        public ActionResult Create(int voteSystemId)
        {
            QuestionViewModel model = new QuestionViewModel();
            model.RateSystemId = voteSystemId;

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var dbModel = this.Mapper.Map<Question>(model);
            this.questions.Add(dbModel);
            
            return this.RedirectToAction<QuestionController>(c => c.Create(model.RateSystemId));
        }

        [HttpPost]
        public ActionResult More()
        {
            return this.PartialView(PartialViewConstants.QuestionAndAnswersPartial);
        }
    }
}