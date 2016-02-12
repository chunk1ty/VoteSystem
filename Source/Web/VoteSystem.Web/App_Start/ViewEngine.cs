namespace VoteSystem.Web.App_Start
{
    using System.Web.Mvc;

    public class ViewEngine
    {
        public static void RegisterViewEngine()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}