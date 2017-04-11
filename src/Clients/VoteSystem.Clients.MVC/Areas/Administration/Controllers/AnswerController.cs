using System.Web.Mvc;

using VoteSystem.Clients.MVC.Areas.Administration.Models.Answer;
using VoteSystem.Common.Constants;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class AnswerController : AdminController
    {
        
        [HttpGet]
        public ActionResult Answer(string containerPrefix)
        {
            ViewBag.ContainerPrefix = containerPrefix;

            return PartialView(PartialViewConstants.AnswerPartial, new AnswerViewModel());
        }
    }
}