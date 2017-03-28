using System.Web.Mvc;

namespace VoteSystem.Clients.MVC.Areas.Administration
{
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
            //context.MapRoute(
            //    "Administration_custom",
            //    "Administration/{action}",
            //    new { controller = "VoteSystem", action = "Index" });

            context.MapRoute(
                name: "Administration_default",
                url: "Administration/{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "VoteSystem",
                    action = "Index",
                    id = UrlParameter.Optional
                });
        }
    }
}