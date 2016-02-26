namespace VoteSystem.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }  
         
        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));
           
            bundles.Add(new ScriptBundle("~/bundles/gentallela-js").Include(
                "~/Content/bootstrap-theme/js/nicescroll/jquery.nicescroll.min.js",
                "~/Content/bootstrap-theme/js/custom.js"
                ));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-social.css"));

            bundles.Add(new StyleBundle("~/Content/forms-css").Include(
                "~/Content/Custom/forms.css"));

            bundles.Add(new StyleBundle("~/Content/gentelella-css").Include(
                "~/Content/bootstrap-theme/fonts/css/font-awesome.min.css", 
                "~/Content/bootstrap-theme/css/animate.min.css", 
                "~/Content/bootstrap-theme/css/custom.css", 
                "~/Content/bootstrap-theme/css/maps/jquery-jvectormap-2.0.1.css", 
                "~/Content/bootstrap-theme/css/icheck/flat/green.css", 
                "~/Content/bootstrap-theme/css/floatexamples.css"));
        }
    }
}
