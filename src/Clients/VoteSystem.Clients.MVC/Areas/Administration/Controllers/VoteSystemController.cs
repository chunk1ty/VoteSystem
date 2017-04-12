using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using VoteSystem.Clients.MVC.Areas.Administration.ViewModels.VoteSystem;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class VoteSystemController : AdminController
    {
        private readonly IVoteSystemService _voteSystemService;
        private readonly IQuestionService _questionService;

        public VoteSystemController(IVoteSystemService voteSystemService, IQuestionService questionService)
        {
            _voteSystemService = voteSystemService ?? throw new ArgumentNullException(nameof(voteSystemService));
            _questionService = questionService ?? throw new ArgumentNullException(nameof(questionService));
        }

        [HttpGet]
        public ActionResult Index()
        {
            var allVoteSystems = _voteSystemService
                                                .All()
                                                .To<VoteSystemViewModel>()
                                                .ToList();

            return View(allVoteSystems);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VoteSystemViewModel model)
        {
            if (!ValidatePostRequest(model))
            {
                return View(model);
            }

            var voteSystemAsDbObject = Mapper.Map<Data.Entities.VoteSystem>(model);
            _voteSystemService.Add(voteSystemAsDbObject);

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int voteSystemId)
        {
            var voteSystem = _voteSystemService.GetById(voteSystemId);

            var voteSystemAsViewModel = Mapper.Map<VoteSystemViewModel>(voteSystem);

            return View(voteSystemAsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VoteSystemViewModel model)
        {
            if (!ValidatePostRequest(model))
            {
                return View(model);
            }

            var voteSystemAsDbObject = Mapper.Map<Data.Entities.VoteSystem>(model);

            _voteSystemService.Update(voteSystemAsDbObject);

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        [HttpPost]
        public ContentResult Delete(int voteSystemId)
        {
            _voteSystemService.Delete(voteSystemId);

            return Content("DELETED");
        }

        [HttpGet]
        public ActionResult Result(int voteSystemId)
        {
            return View(voteSystemId);
        }

        [HttpGet]
        public JsonResult GetVoteSystemResultsById(int voteSystemId)
        {
            if (voteSystemId <= 0)
            {
                return Json("voteSystemId can not be negative number or 0", JsonRequestBehavior.AllowGet);
            }

            var result = _questionService
                                .GetQuestionResultByVoteSystemId(voteSystemId)
                                .ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private bool ValidatePostRequest(VoteSystemViewModel model)
        {
            var isValid = true;

            if (!ModelState.IsValid || model == null)
            {
                isValid =  false;
            }

            if (model.StarDateTime >= model.EndDateTime)
            {
                ModelState.AddModelError(string.Empty, "Началната дата не може да е по голяма от крайната дата.");
                isValid = false;
            }

            return isValid;
        }
    }
}