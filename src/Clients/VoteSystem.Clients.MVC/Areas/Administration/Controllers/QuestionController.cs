using System;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using VoteSystem.Clients.MVC.Areas.Administration.Models.Question;
using VoteSystem.Clients.MVC.ViewModels;
using VoteSystem.Common.Constants;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class QuestionController : AdminController
    {
        private IQuestionService _questionService;

        public QuestionController(IQuestionService questions)
        {
            if (questions == null)
            {
                throw new ArgumentNullException("questionService");
            }

            _questionService = questions;
        }

        [HttpGet]
        public ActionResult Create(int voteSystemId)
        {
            if (voteSystemId <= 0)
            {
                return Content("voteSystemId can not be negative number or 0");
            }

            return View(new QuestionAndAnswersViewModel() { VoteSystemId = voteSystemId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionAndAnswersViewModel model)
        {
            //if (!ModelState.IsValid || model == null)
            //{
            //    return this.View(model);
            //}

            //if (model.Questions.Count() == 0)
            //{
            //    this.ModelState.AddModelError(string.Empty, "Моля добавете най-малко един въпрос!");
            //    return this.View(model);
            //}

            //foreach (var question in model.Questions)
            //{
            //    var questionDbModel = this.Mapper.Map<Question>(question);               
            //    questionDbModel.VoteSystemId = model.VoteSystemId;

            //    this._questionService.Add(questionDbModel);
            //}

            // TODO use dbContext.savechanges
            //this._questionService.SaveChanges();

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int rateSystemId)
        {
            //var questions = this._questionService
            //    .GetQuestionsByVoteSystemId(voteSystemId)
            //    .To<QuestionViewModel>()
            //    .ToList();

            //return this.View(new QuestionAndAnswersViewModel() { Questions = questions, VoteSystemId = voteSystemId });
            return this.View();
        }

        // TODO optimize method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionAndAnswersViewModel model)
        {
            //if (!ModelState.IsValid || model == null)
            //{
            //    return this.View(model);
            //}

            //if (model.Questions.Count() == 0)
            //{
            //    this.ModelState.AddModelError(string.Empty, "Моля добавете най-малко един въпрос!");
            //    return this.View(model);
            //}

            //var allExistingQuestions = this._questionService.GetQuestionsByVoteSystemId(model.VoteSystemId);

            //foreach (var existingQuestion in allExistingQuestions)
            //{
            //    this._questionService.Delete(existingQuestion);
            //}

            //// TODO use dbContext.savechanges
            ////this._questionService.SaveChanges();

            //foreach (var question in model.Questions)
            //{
            //    var questionDbModel = this.Mapper.Map<Question>(question);
            //    questionDbModel.VoteSystemId = model.VoteSystemId;

            //    this._questionService.Add(questionDbModel);
            //}

            // TODO use dbContext.savechanges
            //this._questionService.SaveChanges();

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        public ActionResult Preview(int voteSystemId)
        {
            //var questionsAsVM = this._questionService
            //    .GetQuestionsByVoteSystemId(voteSystemId)
            //    .To<QuestionViewModel>()
            //    .ToList();

            //return this.View(questionsAsVM);
            return this.View();
        }

        [HttpGet]
        public ActionResult GetQuestionsByVoteSystemId(int voteSystemId)
        {
            //var result = this.questions
            //   .GetUsersAnswers(voteSystemId)
            //   .Select(x => new
            //   {
            //       questionName = x.QuestionName,
            //       questionType = x.HasMultipleAnswers,
            //       questionAnswers = x.QuestionAnswers.Select(
            //           y => new
            //           {
            //               questionAnswerName = y.QuestionAnswerName,
            //               userAnswerCount = y.ParticipantAnswers.Count
            //           })
            //   })
            //   .ToList();

            //return this.Json(result, JsonRequestBehavior.AllowGet);
            return this.View();
        }
    }
}