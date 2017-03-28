namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using VoteSystem.Common;
    using VoteSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public abstract class AdministrationController : BaseController
    {       
    }
}