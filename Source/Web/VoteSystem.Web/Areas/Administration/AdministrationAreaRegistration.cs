namespace VoteSystem.Web.Areas.Administration
{
    using System.Web.Mvc;

    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administration_default",
                "Administration/{action}",
                new { controller = "Administration", action = "Index"});
        }
    }
}