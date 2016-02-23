namespace VoteSystem.Web.Controllers
{
    using Data.Models;
    using Services.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using ViewModels;
    using VoteSystem.Web.Infrastructure.Mapping;
    using System.Web.Mvc.Expressions;
    using Microsoft.AspNet.Identity;
    using Data.Common;

    public class FillRateSystemController : BaseController
    {
        private IQuestionService questions;
        private IUserAnswerService userAnswers;
        //private IDbGenericRepository<UserAnswer> userAnswers;
        //IDbGenericRepository<UserAnswer>
        public FillRateSystemController(IQuestionService questions, IUserAnswerService userAnswers)
        {
            this.questions = questions;
            this.userAnswers = userAnswers;
        }

        public ActionResult Fill(int rateSystemID)
        {
            var questions = this.questions
                                .GetAll(rateSystemID)
                                .To<QuestionViewModel>()
                                .ToList();

            return this.View(questions);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fill(IEnumerable<QuestionViewModel> questions)
        {
            // TODO add model validation
            foreach (var question in questions)
            {
                var currentAnswer = new UserAnswer
                {
                    Answer = int.Parse(question.QuestionName),
                    QuestionId = question.Id,
                    UserId = this.User.Identity.GetUserId()
                };

                this.userAnswers.Add(currentAnswer);
            }

            this.userAnswers.SaveChanges();

            return this.RedirectToAction<HomeController>(c => c.Index());
        }
    }
}