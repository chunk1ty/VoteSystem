namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using Services.Data.Contracts;
    using System.Web.Mvc;

    public class ResultController : AdministrationController
    {
        private IUserAnswerService userAnswers;

        public ResultController(IUserAnswerService userAnswers)
        {
            this.userAnswers = userAnswers;
        }

        public ActionResult Index(int reteSystemId)
        {
            return this.View();
        }
    }
}