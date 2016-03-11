namespace VoteSystem.Web.Controllers
{   
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using Microsoft.AspNet.Identity;

    using ViewModels.FillRateSystem;
    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Web.Infrastructure.Mapping;

    [Authorize]
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

        public ActionResult Fill(string rateSystemID)
        {
            var questions = this.questions
                                .GetAllQuestions(rateSystemID)
                                .To<FillQuestionsViewModel>()
                                .ToList();

            return this.View(questions);
        }
        
        // TODO this method looks so ugly make it beautiful ...
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
                var currentAnswer = new ParticipantAnswer();

                if (question.HasMultipleAnswers)
                {
                    foreach (var answer in question.QuestionAnswers)
                    {
                        if (answer.IsChecked)
                        {
                            currentAnswer.QuestionAnswerId = answer.Id;
                            currentAnswer.ParticipantId = participant.Id.ToString();

                            this.participantAnswers.Add(currentAnswer);
                            this.participantAnswers.SaveChanges();
                        }
                    }
                }
                else
                {
                    currentAnswer.QuestionAnswerId = int.Parse(question.QuestionName);
                    currentAnswer.ParticipantId = participant.Id.ToString();

                    this.participantAnswers.Add(currentAnswer);
                    this.participantAnswers.SaveChanges();
                } 
            }

            return this.RedirectToAction<HomeController>(c => c.Index());
        }
    }
}