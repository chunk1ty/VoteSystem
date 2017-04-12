using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using VoteSystem.Clients.MVC.Areas.Administration.ViewModels.VoteSystem;
using VoteSystem.Clients.MVC.Areas.Administration.ViewModels.VoteSystemUser;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Clients.MVC.Infrastructure.NotificationSystem;
using VoteSystem.Common.Constants;
using VoteSystem.Data.Services.Contracts;
using VotySystem.Data.DTO;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class ParticipantController : AdminController
    {
        private readonly IVoteSystemUserService _voteSystemUserService;
        private IParticipantService _participantService;
        private IVoteSystemService _voteSystemService;

        public ParticipantController(
            IVoteSystemUserService voteSystemUserService, 
            IParticipantService participantService, 
            IVoteSystemService voteSystemService)
        {
            _voteSystemUserService = voteSystemUserService;
            _participantService = participantService;
            _voteSystemService = voteSystemService;
        }
        
        [HttpGet]
        public ActionResult Add(int voteSystemId)
        {
            var voteSystemUser = _voteSystemUserService
                                                    .GetUnselectedUsers(voteSystemId)
                                                    .To<VoteSystemUserViewModel>()
                                                    .ToList();

            var voteSystemParticipantsViewModel = new VoteSystemParticipantsViewModel
            {
                VoteSystemUsers = voteSystemUser,
                VoteSystemId = voteSystemId
            };

            return View(voteSystemParticipantsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(VoteSystemParticipantsViewModel model)
        {
            if (!ValidateRequest(model))
            {
                return View(model);
            }

            var voteSystemParticipantsAsDto = Mapper.Map<VoteSystemParticipantsDto>(model);
            _participantService.AddParticipants(voteSystemParticipantsAsDto);

            this.AddNotification("Успешно добавихте учасници!", NotificationType.Success);

            return this.RedirectToAction<ParticipantController>(c => c.Add(model.VoteSystemId));
        }

        public ActionResult Remove(int rateSystemId)
        {
            //var _voteSystemUserService = this._voteSystemUserService
            //    .GetSelectedUsers(voteSystemId)
            //    .To<UserViewModel>()
            //    .ToList();

            //var userSelectedVM = new VoteSystemParticipantsViewModel()
            //{
            //    VoteSystemUsers = _voteSystemUserService,
            //    VoteSystemId = voteSystemId
            //};

            //return this.View(userSelectedVM);
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(VoteSystemParticipantsViewModel model)
        {
            //var getSelectedUsers = model.GetSelectedUsers();

            //if (getSelectedUsers.Count == 0)
            //{
            //    this.ModelState.AddModelError(string.Empty, "Трябва да изберете най-малко един учасник.");
            //    return this.View(model);
            //}

            //foreach (var participant in getSelectedUsers)
            //{
            //    var currentParticipant = this._participantService.GetParticipantBySurveyIdAndUserId(model.VoteSystemId, participant.Id);

            //    if (currentParticipant == null)
            //    {
            //        throw new ArgumentNullException("Participant can not be found!");
            //    }

            //    this._participantService.Remove(currentParticipant);
            //}

            // TODO use dbContext.savechanges
            //this._participantService.SaveChanges();

            return this.RedirectToAction<ParticipantController>(c => c.Remove(model.VoteSystemId));
        }

        public ActionResult Preview(int rateSystemId)
        {
            //var _voteSystemUserService = this._voteSystemUserService
            //    .GetSelectedUsers(voteSystemId)
            //    .To<UserViewModel>()
            //    .ToList();

            //var userSelectedVM = new VoteSystemParticipantsViewModel()
            //{
            //    VoteSystemUsers = _voteSystemUserService,
            //    VoteSystemId = voteSystemId
            //};

            //return this.View(userSelectedVM);
            return this.View();
        }

        public async Task<ActionResult> SentEmails(int rateSystemId)
        {
            //var _voteSystemUserService = this._voteSystemUserService
            //    .GetSelectedUsers(voteSystemId)
            //    .Select(x => x.Email).ToList();

            //var rateSystem = this._voteSystemService.GetById(voteSystemId);

            //EmailService email = new EmailService();
            //await email.SendAddedParticipantsAsync(_voteSystemUserService, rateSystem);

            //this.AddNotification("Успешно изпратихте имейли на всички учасници!", NotificationType.Success);

            return PartialView(PartialViewConstants.SuccessNotificationPartial);
        }

        private bool ValidateRequest(VoteSystemParticipantsViewModel model)
        {
            var IsValid = true;

            if (!ModelState.IsValid || model == null)
            {
                IsValid = false;
            }

            if (!model.SelectedVoteSystemUsers.Any())
            {
                ModelState.AddModelError(string.Empty, "Трябва да изберете най-малко един учасник.");
                IsValid = false;
            }

            return IsValid;
        }
    }
}