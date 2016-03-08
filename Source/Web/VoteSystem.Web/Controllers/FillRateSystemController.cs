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
    using ViewModels.FillRateSystem;

    public class FillRateSystemController : BaseController
    {
        private IQuestionService questions;
        private IParticipantService participants;
        private IParticipantAnswerService participantAnswers;
        
        public FillRateSystemController(IQuestionService questions, IParticipantService participants, IParticipantAnswerService userAnswers)
        {
            this.questions = questions;
            this.participants = participants;
            this.participantAnswers = userAnswers;
        }

        public ActionResult Fill(int rateSystemID)
        {
            var questions = this.questions
                                .GetAllQuestions(rateSystemID)
                                .To<FillQuestionsViewModel>()
                                .ToList();

            return this.View(questions);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fill(IList<FillQuestionsViewModel> questions)
        {
            if (!ModelState.IsValid)
            {
                return this.View(questions);
            }

            var participant = this.participants.GetParticipantByRateSystemIdAndUserId(questions[0].RateSystemId, User.Identity.GetUserId());

            foreach (var question in questions)
            {
                var currentAnswer = new ParticipantAnswer
                {
                    QuestionAnswerId = int.Parse(question.QuestionName),
                    ParticipantId = participant.Id.ToString()
                };

                this.participantAnswers.Add(currentAnswer);
            }

            this.participantAnswers.SaveChanges();

            return this.RedirectToAction<HomeController>(c => c.Index());
        }
    }
}