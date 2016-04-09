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
    using VoteSystem.Web.Infrastructure.NotificationSystem;

    public class FillRateSystemController : BaseController
    {
        private IQuestionService questions;
        private IParticipantService participant;
        private IParticipantAnswerService participantAnswers;
        
        public FillRateSystemController(IQuestionService questions, IParticipantService participant, IParticipantAnswerService userAnswers)
        {
            this.questions = questions;
            this.participant = participant;
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

            var participant = this.participant.GetParticipantByRateSystemIdAndUserId(questions[0].RateSystemId, User.Identity.GetUserId());

            foreach (var question in questions)
            {
                var currentAnswer = new ParticipantAnswer();

                if (question.HasMultipleAnswers)
                {
                    bool isNotChecked = question.QuestionAnswers.All(x => x.IsChecked == false);

                    if (isNotChecked)
                    {
                        this.ModelState.AddModelError(question.Id.ToString(), "Моля изберете най-малко един отговор!");
                        return this.View(questions);
                    }

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
                    if (question.RadioGroupAnswer == null)
                    {
                        this.ModelState.AddModelError(question.Id.ToString(), "Моля изберете отговор!");
                        return this.View(questions);
                    }

                    currentAnswer.QuestionAnswerId = int.Parse(question.RadioGroupAnswer);
                    currentAnswer.ParticipantId = participant.Id.ToString();

                    this.participantAnswers.Add(currentAnswer);
                    this.participantAnswers.SaveChanges();
                } 
            }

            participant.IsVoted = true;
            this.participant.Update(participant);
            this.participant.SaveChanges();            

            this.AddNotification("Благодаря Ви, че гласувахте! Вашият глас е важен за мен.", NotificationType.SUCCESS);

            return this.RedirectToAction<HomeController>(c => c.Index());
        }
    }
}