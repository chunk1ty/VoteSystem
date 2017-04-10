using System.Web.Mvc;

using VoteSystem.Clients.MVC.ViewModels;
using VoteSystem.Common.Constants;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class QuestionAnswerController : AdminController
    {
        [HttpGet]
        public ActionResult NewQuestion()
        {
            return this.PartialView(PartialViewConstants.QuestionPartial, new QuestionViewModel());
        }
        
        [HttpGet]
        public ActionResult NewAnswer(string containerPrefix)
        {
            ViewBag.ContainerPrefix = containerPrefix;

            return this.PartialView(PartialViewConstants.AnswerPartial, new AnswerViewModel());
        }
    }
}