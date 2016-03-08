namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using VoteSystem.Services.Data.Contracts;    

    public class ResultController : AdministrationController
    {
        private IQuestionService questions;

        public ResultController(IQuestionService questions)
        {
            this.questions = questions;
        }

        public ActionResult Index(int rateSystemId)
        {
            return this.View(rateSystemId);
        }

        public ActionResult GetAllQuestions(int rateSystemId)
        {
            var result = this.questions
               .GetUsersAnswers(rateSystemId)
               .Select(x => new
               {
                   questionName = x.QuestionName,
                   questionAnswers = x.QuestionAnswers.Select(
                       y => new
                       {
                           questionAnswerName = y.QuestionAnswerName,
                           userAnswerCount = y.ParticipantAnswers.Count
                       })
               })
               .ToList();

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}