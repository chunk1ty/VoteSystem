using System.Linq;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using VoteSystem.Clients.MVC.Areas.Administration.Models.VoteSystem;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Clients.MVC.ViewModels;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IVoteSystemService _voteSystemService;

        public HomeController(IVoteSystemService voteSystemService)
        {
            this._voteSystemService = voteSystemService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var voteSystems = _voteSystemService
                            .GetAllAvailableVoteSystemsForUser(User.Identity.GetUserId())
                            .To<VoteSystemViewModel>()
                            .ToList();

            return this.View(voteSystems);
        }
    }
}