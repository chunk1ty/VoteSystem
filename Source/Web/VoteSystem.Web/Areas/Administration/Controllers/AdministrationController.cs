namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using Services.Data.Contracts;
    using System.Web.Mvc;
    using ViewModels;
    using VoteSystem.Common;
    using Web.Controllers;
    using VoteSystem.Web.Infrastructure.Mapping;
    using Data.Models;
    using System.Linq;
    using System.Web.Mvc.Expressions;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
       
    }
}