namespace VoteSystem.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }   
        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            
            // TODO separate in different bundle files
            bundles.Add(new ScriptBundle("~/bundles/gentallela-js").Include(
                //"~/Content/bootstrap-theme/js/bootstrap.min.js",
                "~/Content/bootstrap-theme/js/gauge/gauge.min.js",
                "~/Content/bootstrap-theme/js/gauge/gauge_demo.js",
                "~/Content/bootstrap-theme/js/chartjs/chart.min.js",
                "~/Content/bootstrap-theme/js/progressbar/bootstrap-progressbar.min.js",
                "~/Content/bootstrap-theme/js/nicescroll/jquery.nicescroll.min.js",
                "~/Content/bootstrap-theme/js/icheck/icheck.min.js",
                "~/Content/bootstrap-theme/js/moment.min.js",
                "~/Content/bootstrap-theme/js/datepicker/daterangepicker.js",
                "~/Content/bootstrap-theme/js/custom.js",
                "~/Content/bootstrap-theme/js/excanvas.min.js",
                "~/Content/bootstrap-theme/js/flot/jquery.flot.js",
                "~/Content/bootstrap-theme/js/flot/jquery.flot.pie.js",
                "~/Content/bootstrap-theme/js/flot/jquery.flot.orderBars.js",
                "~/Content/bootstrap-theme/js/flot/jquery.flot.time.min.js",
                "~/Content/bootstrap-theme/js/flot/date.js" ,
                "~/Content/bootstrap-theme/js/flot/jquery.flot.spline.js" ,
                "~/Content/bootstrap-theme/js/flot/jquery.flot.stack.js" ,
                "~/Content/bootstrap-theme/js/flot/curvedLines.js" ,
                "~/Content/bootstrap-theme/js/flot/jquery.flot.resize.js" ,
                "~/Content/bootstrap-theme/js/maps/jquery-jvectormap-2.0.1.min.js",                
                "~/Content/bootstrap-theme/js/maps/gdp-data.js",
                "~/Content/bootstrap-theme/js/maps/jquery-jvectormap-world-mill-en.js",
                "~/Content/bootstrap-theme/js/maps/jquery-jvectormap-us-aea-en.js",
                "~/Content/bootstrap-theme/js/skycons/skycons.js"
                ));
            //<script src = "~/Content/bootstrap-theme/js/jquery.min.js" ></ script >
            //< script src="~/Content/bootstrap-theme/js/nprogress.js"></script>
            //<script src = "~/Content/bootstrap-theme/js/bootstrap.min.js" ></ script >

            //< !--gauge js -->
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/gauge/gauge.min.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/gauge/gauge_demo.js"></script>

            //<!-- chart js -->
            //<script src = "~/Content/bootstrap-theme/js/chartjs/chart.min.js" ></ script >

            //< !--bootstrap progress js -->
            //<script src = "~/Content/bootstrap-theme/js/progressbar/bootstrap-progressbar.min.js" ></ script >
            //< script src="~/Content/bootstrap-theme/js/nicescroll/jquery.nicescroll.min.js"></script>

            //<!-- icheck -->
            //<script src = "~/Content/bootstrap-theme/js/icheck/icheck.min.js" ></ script >
            //< !--daterangepicker-- >
            //< script type="text/javascript" src="~/Content/bootstrap-theme/js/moment.min.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/datepicker/daterangepicker.js"></script>
            //<script src = "~/Content/bootstrap-theme/js/custom.js" ></ script >
            //< !--flot js -->
            //<!--[if lte IE 8]><script type = "text/javascript" src="js/excanvas.min.js"></script><![endif]-->
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/flot/jquery.flot.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/flot/jquery.flot.pie.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/flot/jquery.flot.orderBars.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/flot/jquery.flot.time.min.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/flot/date.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/flot/jquery.flot.spline.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/flot/jquery.flot.stack.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/flot/curvedLines.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/flot/jquery.flot.resize.js"></script>

            //<!-- worldmap -->
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/maps/jquery-jvectormap-2.0.1.min.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/maps/gdp-data.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/maps/jquery-jvectormap-world-mill-en.js"></script>
            //<script type = "text/javascript" src="~/Content/bootstrap-theme/js/maps/jquery-jvectormap-us-aea-en.js"></script>

            //          <!-- skycons -->
            //<script src = "~/Content/bootstrap-theme/js/skycons/skycons.js" ></ script >
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css",
                                                                       "~/Content/bootstrap-social.css"));

            bundles.Add(new StyleBundle("~/Content/forms-css").Include("~/Content/css/forms.css"));

            //<link href = "~/Content/bootstrap-theme/css/bootstrap.min.css" rel="stylesheet">
            //<link href = "~/Content/bootstrap-theme/fonts/css/font-awesome.min.css" rel="stylesheet">
            //<link href = "~/Content/bootstrap-theme/css/animate.min.css" rel="stylesheet">
            //<!-- Custom styling plus plugins -->
            //<link href = "~/Content/bootstrap-theme/css/custom.css" rel="stylesheet">
            //<link rel = "stylesheet" type="text/css" href="~/Content/bootstrap-theme/css/maps/jquery-jvectormap-2.0.1.css" />
            //<link href = "~/Content/bootstrap-theme/css/icheck/flat/green.css" rel="stylesheet" />
            //<link href = "~/Content/bootstrap-theme/css/floatexamples.css" rel="stylesheet" type="text/css" />

            bundles.Add(new StyleBundle("~/Content/gentelella-css").Include(
                //"~/Content/bootstrap-theme/css/bootstrap.min.css",
                "~/Content/bootstrap-theme/fonts/css/font-awesome.min.css", 
                "~/Content/bootstrap-theme/css/animate.min.css", 
                "~/Content/bootstrap-theme/css/custom.css", 
                "~/Content/bootstrap-theme/css/maps/jquery-jvectormap-2.0.1.css", 
                "~/Content/bootstrap-theme/css/icheck/flat/green.css", 
                "~/Content/bootstrap-theme/css/floatexamples.css"));
        }
    }
}
