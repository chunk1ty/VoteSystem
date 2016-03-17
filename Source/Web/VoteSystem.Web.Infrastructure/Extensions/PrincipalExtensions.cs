namespace VoteSystem.Web.Infrastructure.Extensions
{
    using System.Security.Principal;

    using VoteSystem.Common;

    public static class PrincipalExtensions
    {
        public static bool IsAdministrator(this IPrincipal principal)
        {
            if (principal == null)
            {
                return false;
            }

            return principal.IsInRole(GlobalConstants.AdministratorRoleName);
        }
    }
}
