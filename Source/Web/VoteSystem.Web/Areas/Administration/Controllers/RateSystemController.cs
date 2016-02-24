﻿namespace VoteSystem.Web.Areas.Administration.Controllers
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
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var modelDb = this.Mapper.Map<RateSystem>(model);
            this.rateSystems.Add(modelDb);
            this.rateSystems.SaveChanges();

            return this.RedirectToAction<RateSystemController>(c => c.Index());
        }
    }
}