using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;

using VoteSystem.Clients.MVC.Areas.Administration.Models.User;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Common.Constants;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class UserController : AdminController
    {
        private readonly IVoteSystemUserService _voteSystemUserService;
        private IParticipantService _participantService;
        private IVoteSystemService _voteSystemService;

        public UserController(
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
            var voteSystemUserService = _voteSystemUserService
                                                        .GetAllUnselectUsers(voteSystemId)
                                                        .To<UserViewModel>()
                                                        .ToList();

            var userSelectedVM = new UserSelectedViewModel()
            {
                Users = voteSystemUserService,
                VoteSystemId = voteSystemId
            };

            return View(userSelectedVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(UserSelectedViewModel model)
        {
            //var getSelectedUsers = model.GetSelectedUsers();

            //if (getSelectedUsers.Count == 0)
            //{
            //    this.ModelState.AddModelError(string.Empty, "Трябва да изберете най-малко един учасник.");
            //    return this.View(model);
            //}

            //foreach (var participant in getSelectedUsers)
            //{
            //    var currentParticipant = new Participant()
            //    {
            //        VoteSystemId = model.VoteSystemId,
            //        // TODO fix it later
            //        //UserId = participant.Id
            //    };

            //    this._participantService.Add(currentParticipant);
            //}

            //// TODO use dbContext.savechanges
            ////this._participantService.SaveChanges();

            //this.AddNotification("Успешно добавихте учасници!", NotificationType.SUCCESS);

            return this.RedirectToAction<UserController>(c => c.Add(model.VoteSystemId));
        }

        public ActionResult Remove(int rateSystemId)
        {
            //var _voteSystemUserService = this._voteSystemUserService
            //    .GetAllSelectUsers(voteSystemId)
            //    .To<UserViewModel>()
            //    .ToList();

            //var userSelectedVM = new UserSelectedViewModel()
            //{
            //    Users = _voteSystemUserService,
            //    VoteSystemId = voteSystemId
            //};

            //return this.View(userSelectedVM);
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(UserSelectedViewModel model)
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

            return this.RedirectToAction<UserController>(c => c.Remove(model.VoteSystemId));
        }

        public ActionResult Preview(int rateSystemId)
        {
            //var _voteSystemUserService = this._voteSystemUserService
            //    .GetAllSelectUsers(voteSystemId)
            //    .To<UserViewModel>()
            //    .ToList();

            //var userSelectedVM = new UserSelectedViewModel()
            //{
            //    Users = _voteSystemUserService,
            //    VoteSystemId = voteSystemId
            //};

            //return this.View(userSelectedVM);
            return this.View();
        }

        public async Task<ActionResult> SentEmails(int rateSystemId)
        {
            //var _voteSystemUserService = this._voteSystemUserService
            //    .GetAllSelectUsers(voteSystemId)
            //    .Select(x => x.Email).ToList();

            //var rateSystem = this._voteSystemService.GetById(voteSystemId);

            //EmailService email = new EmailService();
            //await email.SendAddedParticipantsAsync(_voteSystemUserService, rateSystem);

            //this.AddNotification("Успешно изпратихте имейли на всички учасници!", NotificationType.SUCCESS);

            return this.PartialView(PartialViewConstants.SuccessNotificationPartial);
        }
    }
}