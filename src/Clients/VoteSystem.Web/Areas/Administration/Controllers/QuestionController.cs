using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using VoteSystem.Clients.MVC.ViewModels;
using VoteSystem.Data.Models;
using VoteSystem.Services.Data.Contracts;
using VoteSystem.Web.Infrastructure.Mapping;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class QuestionController : AdministrationController
    {
        private IQuestionService questionService;

        public QuestionController(IQuestionService questions)
        {
            if (questions == null)
            {
                throw new ArgumentNullException("questionService");
            }
            this.questionService = questions;
        }

        [HttpGet]
        public ActionResult Create(int rateSystemId)
        {
            if (rateSystemId <= 0)
            {
                return this.Content("rateSystemId can not be negative number or 0");
            }

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
                this.ModelState.AddModelError(string.Empty, "Моля добавете най-малко един въпрос!");
                return this.View(model);
            }

            foreach (var question in model.Questions)
            {
                var questionDbModel = this.Mapper.Map<Question>(question);               
                questionDbModel.RateSystemId = model.RateSystemId;

                this.questionService.Add(questionDbModel);
            }

            this.questionService.SaveChanges();

            return this.RedirectToAction<RateSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int rateSystemId)
        {
            var questions = this.questionService
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
                this.ModelState.AddModelError(string.Empty, "Моля добавете най-малко един въпрос!");
                return this.View(model);
            }

            var allExistingQuestions = this.questionService.GetAllQuestions(model.RateSystemId);

            foreach (var existingQuestion in allExistingQuestions)
            {
                this.questionService.Delete(existingQuestion);
            }

            this.questionService.SaveChanges();

            foreach (var question in model.Questions)
            {
                var questionDbModel = this.Mapper.Map<Question>(question);
                questionDbModel.RateSystemId = model.RateSystemId;

                this.questionService.Add(questionDbModel);
            }

            this.questionService.SaveChanges();

            return this.RedirectToAction<RateSystemController>(c => c.Index());
        }
        
        public ActionResult Preview(int rateSystemId)
        {
            var questionsAsVM = this.questionService
                .GetAllQuestions(rateSystemId)
                .To<QuestionViewModel>()
                .ToList();

            return this.View(questionsAsVM);
        }
    }
}