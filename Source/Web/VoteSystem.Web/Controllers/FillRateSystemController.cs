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

    public class FillRateSystemController : BaseController
    {
        private IQuestionService questions;

        public FillRateSystemController(IQuestionService questions)
        {
            this.questions = questions;
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
        public ActionResult Fill(IEnumerable<QuestionViewModel> questions)
        {
            return this.View();
        }
    }
}