namespace VoteSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using Microsoft.AspNet.Identity;

    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Web.Infrastructure.Mapping;
    using VoteSystem.Web.ViewModels;

    public class FillRateSystemController : BaseController
    {
        private IQuestionService questions;
        private IUserAnswerService userAnswers;
        
        public FillRateSystemController(IQuestionService questions, IUserAnswerService userAnswers)
        {
            this.questions = questions;
            this.userAnswers = userAnswers;
        }

        public ActionResult Fill(int rateSystemID)
        {
            var questions = this.questions
                                .GetAllQuestions(rateSystemID)
                                .To<QuestionViewModel>()
                                .ToList();

            return this.View(questions);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fill(IEnumerable<QuestionViewModel> questions)
        {
            if (!ModelState.IsValid)
            {
                return this.View(questions);
            }
           
            foreach (var question in questions)
            {
                var currentAnswer = new UserAnswer
                {
                    QuestionAnswerId = int.Parse(question.QuestionName),
                    UserId = this.User.Identity.GetUserId()
                };

                this.userAnswers.Add(currentAnswer);
            }

            this.userAnswers.SaveChanges();

            return this.RedirectToAction<HomeController>(c => c.Index());
        }
    }
}