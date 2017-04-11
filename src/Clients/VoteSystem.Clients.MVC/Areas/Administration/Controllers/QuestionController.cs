using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;

using VoteSystem.Clients.MVC.Areas.Administration.Models.Question;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Common.Constants;
using VoteSystem.Data.Entities;
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

            ViewBag.VoteSystemId = voteSystemId;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IEnumerable<QuestionViewModel> model)
        {
            //if (!ValidatePostRequest(model))
            //{
            //    return View(model);
            //}

            //foreach (var question in model.Questions)
            //{
            //    // TODO Bulk insert
            //    var questionAsDbModel = Mapper.Map<Question>(question);
            //    questionAsDbModel.VoteSystemId = model.VoteSystemId;

            //    _questionService.Add(questionAsDbModel);
            //}

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int voteSystemId)
        {
            var questions = _questionService
                                    .GetQuestionsWithAnswersByVoteSystemId(voteSystemId)
                                    .To<QuestionViewModel>()
                                    .ToList();

            var voteSystem = new VoteSystemWithQuestionsViewModel()
            {
                Questions = questions,
                VoteSystemId = voteSystemId
            };

            return View(voteSystem);
        }

        // TODO optimize method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VoteSystemWithQuestionsViewModel model)
        {
            if (!ValidatePostRequest(model))
            {
                return View(model);
            }

            //var allExistingQuestions = _questionService.GetQuestionsWithAnswersByVoteSystemId(model.VoteSystemId);

            //foreach (var existingQuestion in allExistingQuestions)
            //{
            //    _questionService.Delete(existingQuestion);
            //}

            //// TODO use dbContext.savechanges
            ////this._questionService.SaveChanges();

            //foreach (var question in model.Questions)
            //{
            //    var questionDbModel = this.Mapper.Map<Question>(question);
            //    questionDbModel.VoteSystemId = model.VoteSystemId;

            //    this._questionService.Add(questionDbModel);
            //}

            ////TODO use dbContext.savechanges
            //this._questionService.SaveChanges();

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        public ActionResult Preview(int voteSystemId)
        {
            //var questionsAsVM = this._questionService
            //    .GetQuestionsWithAnswersByVoteSystemId(voteSystemId)
            //    .To<QuestionViewModel>()
            //    .ToList();

            //return this.View(questionsAsVM);
            return this.View();
        }

        [HttpGet]
        public ActionResult Question(int voteSystemId)
        {
            var questionViewModel = new QuestionViewModel
            {
                VoteSystemId = voteSystemId
            };

            return PartialView(PartialViewConstants.QuestionPartial, questionViewModel);
        }


        [HttpGet]
        public ActionResult GetQuestionsByVoteSystemId(int voteSystemId)
        {
            //var result = this.questions
            //   .GetUsersAnswers(voteSystemId)
            //   .Select(x => new
            //   {
            //       questionName = x.Name,
            //       questionType = x.HasMultipleAnswers,
            //       questionAnswers = x.Answers.Select(
            //           y => new
            //           {
            //               questionAnswerName = y.Name,
            //               userAnswerCount = y.ParticipantAnswers.Count
            //           })
            //   })
            //   .ToList();

            //return this.Json(result, JsonRequestBehavior.AllowGet);
            return this.View();
        }

        private bool ValidatePostRequest(VoteSystemWithQuestionsViewModel model)
        {
            bool isValid = true;

            if (!ModelState.IsValid || model == null)
            {
                isValid = false;
            }

            if (!model.Questions.Any())
            {
                ModelState.AddModelError(string.Empty, "Моля добавете най-малко един въпрос!");
                isValid = false;
            }

            return isValid;
        }
    }
}