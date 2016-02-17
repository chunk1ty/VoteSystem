namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using Data.Models;
    using Services.Data.Contracts;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using ViewModels;
    using Web.Controllers;
    using VoteSystem.Web.Infrastructure.Mapping;
    using System.Linq;
    public class VoteSystemController : AdministrationController
    {
        private IRateSystemService rateSystems;

        public VoteSystemController(IRateSystemService rateSystems)
        {
            this.rateSystems = rateSystems;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var allVoteSystems = this.rateSystems
                                        .GetAll()
                                        .To<RateSystemViewModel>()
                                        .ToList();

            return this.View(allVoteSystems);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RateSystemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var dbModel = this.Mapper.Map<RateSystem>(model);
            this.rateSystems.Add(dbModel);

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }
    }
}