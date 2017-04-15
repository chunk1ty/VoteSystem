using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using Microsoft.AspNet.Identity;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Clients.MVC.Infrastructure.NotificationSystem;
using VoteSystem.Clients.MVC.ViewModels.ParticipantAnswer;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Controllers
{
    public class ParticipantAnswerController : BaseController
    {
        private readonly IQuestionService _questionService;
        private IParticipantService participant;
        private IParticipantAnswerService participantAnswers;
        
        public ParticipantAnswerController(
            IQuestionService questionService, 
            IParticipantService participant, 
            IParticipantAnswerService userAnswers)
        {
            _questionService = questionService;
            participant = participant;
            participantAnswers = userAnswers;
        }

        [HttpGet]
        public ActionResult Answer(string voteSystemId)
        {
            var questionsAsViewModel = _questionService
                                            .GetQuestionsWithAnswersByVoteSystemId(voteSystemId)
                                            .To<ParticipantQuestionViewModel>()
                                            .ToList();

            return View(questionsAsViewModel);
        }
        
        // TODO this method looks so ugly make it beautiful ...
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Answer(IList<ParticipantQuestionViewModel> questions)
        {
            if (!ModelState.IsValid)
            {
                return this.View(questions);
            }

            var participant = this.participant.GetParticipantBySurveyIdAndUserId(questions[0].VoteSystemId, new Guid(User.Identity.GetUserId()));

            foreach (var question in questions)
            {
                var currentAnswer = new ParticipantAnswer();

                if (question.HasMultipleAnswers)
                {
                    bool isNotChecked = question.Answers.All(x => x.IsChecked == false);

                    if (isNotChecked)
                    {
                        this.ModelState.AddModelError(question.Id.ToString(), "Моля изберете най-малко един отговор!");
                        return this.View(questions);
                    }

                    foreach (var answer in question.Answers)
                    {
                        if (answer.IsChecked)
                        {
                            currentAnswer.AnswerId = answer.Id;
                            currentAnswer.ParticipantId = participant.Id;

                            this.participantAnswers.Add(currentAnswer);
                            // TODO use dbContext.savechanges
                            //this.participantAnswers.SaveChanges();
                        }
                    }
                }
                else
                {
                    //if (question.RadioGroupQuestion == null)
                    //{
                    //    this.ModelState.AddModelError(question.Id.ToString(), "Моля изберете отговор!");
                    //    return this.View(questions);
                    //}

                    //currentAnswer.AnswerId = int.Parse(question.RadioGroupQuestion);
                    //currentAnswer.ParticipantId = participant.Id;

                    this.participantAnswers.Add(currentAnswer);
                    // TODO use dbContext.savechanges
                    //this.participantAnswers.SaveChanges();
                }
            }

            participant.IsVoted = true;
            this.participant.Update(participant);
            // TODO use dbContext.savechanges
            //this.participant.SaveChanges();            

            this.AddNotification("Благодаря Ви, че гласувахте! Вашият глас е важен за мен.", NotificationType.Success);

            return this.RedirectToAction<DashboardController>(c => c.Index());
        }
    }
}