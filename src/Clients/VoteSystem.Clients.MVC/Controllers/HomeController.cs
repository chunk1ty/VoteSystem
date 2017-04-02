using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Clients.MVC.ViewModels;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private IRateSystemService rateSystems;

        public HomeController(IRateSystemService rateSystems)
        {
            this.rateSystems = rateSystems;
        }

        public ActionResult Index()
        {
            //var systems = this.rateSystems
            //                .AllActive(User.Identity.GetUserId())
            //                .To<RateSystemViewModel>()
            //                .ToList();

            //return this.View(systems);
            return this.View();
        }
    }
}