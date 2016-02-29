namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using VoteSystem.Data.Models;
    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Web.Infrastructure.Mapping;
    using VoteSystem.Web.ViewModels;

    public class RateSystemController : AdministrationController
    {
        private IRateSystemService rateSystems;

        public RateSystemController(IRateSystemService rateSystems)
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
            if (!ModelState.IsValid || model == null)
            {
                return this.View(model);
            }

            if (model.StarDateTime >= model.EndDateTime)
            {
                this.ModelState.AddModelError(string.Empty, "Start date can not be greater than end date.");
                return this.View(model);
            }

            var modelDb = this.Mapper.Map<RateSystem>(model);
            this.rateSystems.Add(modelDb);

            return this.RedirectToAction<RateSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int rateSystemId)
        {
            var rateSystem = this.rateSystems.GetById(rateSystemId);
            var rateSystemVM = this.Mapper.Map<RateSystemViewModel>(rateSystem);

            return this.View(rateSystemVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RateSystemViewModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return this.View(model);
            }

            if (model.StarDateTime >= model.EndDateTime)
            {
                this.ModelState.AddModelError(string.Empty, "Start date can not be greater than end date.");
                return this.View(model);
            }

            var rateSystemDb = this.rateSystems.GetById(model.Id);

            if (rateSystemDb == null)
            {
                this.ModelState.AddModelError(string.Empty, "The rate system is not found");
                return this.View(model);
            }

            rateSystemDb.RateSystemName = model.RateSystemName;
            rateSystemDb.StarDateTime = model.StarDateTime;
            rateSystemDb.EndDateTime = model.EndDateTime;

            this.rateSystems.Update(rateSystemDb);

            return this.RedirectToAction<RateSystemController>(c => c.Index());
        }
    }
}