using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;

using VoteSystem.Clients.MVC.Areas.Administration.Models.Question;
using VoteSystem.Clients.MVC.Areas.Administration.Models.VoteSystem;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Common.Constants;
using VoteSystem.Data.Services.Contracts;
using VotySystem.Data.DTO;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class QuestionController : AdminController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService ?? throw new ArgumentNullException(nameof(questionService));
        }

        [HttpGet]
        public ActionResult Create(int voteSystemId)
        {
            if (voteSystemId <= 0)
            {
                return Content("voteSystemId cannot be negative number or 0");
            }

            ViewBag.VoteSystemId = voteSystemId;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VoteSystemWithQuestionsViewModel voteSystem)
        {
            if (!ValidatePostRequest(voteSystem))
            {
                return View(voteSystem);
            }

            _questionService.AddQuestions(Mapper.Map<VoteSystemWithQuestionsDto>(voteSystem));

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int voteSystemId)
        {
            var questions = _questionService
                                    .GetQuestionsWithAnswersByVoteSystemId(voteSystemId)
                                    .To<QuestionViewModel>()
                                    .ToList();

            ViewBag.VoteSystemId = voteSystemId;

            var voteSystem = new VoteSystemWithQuestionsViewModel()
            {
                Questions = questions
            };

            return View(voteSystem);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VoteSystemWithQuestionsViewModel voteSystem)
        {
            if (!ValidatePostRequest(voteSystem))
            {
                return View(voteSystem);
            }

            var voteSystemAsDto = Mapper.Map<VoteSystemWithQuestionsDto>(voteSystem);

            _questionService.UpdateQuestions(voteSystemAsDto);

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Preview(int voteSystemId)
        {
            var questionsAsViewModel = _questionService
                                                    .GetQuestionsWithAnswersByVoteSystemId(voteSystemId)
                                                    .To<QuestionViewModel>()
                                                    .ToList();

            return View(questionsAsViewModel);
        }

        [HttpGet]
        public PartialViewResult Question(int voteSystemId)
        {
            var questionViewModel = new QuestionViewModel
            {
                VoteSystemId = voteSystemId
            };

            return PartialView(PartialViewConstants.QuestionPartial, questionViewModel);
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