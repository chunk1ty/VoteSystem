namespace VoteSystem.Web.Routes.Tests
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    //using MvcRouteTester;

    [TestClass]
    public class IntroductionRouteTests
    {
        [TestMethod]
        public void HasIntroRoute()
        {
            const string Route = "/Introduction/Intro";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
//            /RouteAssert.HasRoute(routeCollection, Route);

            // routeCollection.ShouldMap(route).To<IntroductionController>( x => x.Intro());
        }

        // [TestMethod]
        // public void IntroRouteWithIndex()
        // {
        //    const string route = "/Introduction/Intro";
        //    var routeCollection = new RouteCollection();
        //    RouteConfig.RegisterRoutes(routeCollection);
        //    RouteAssert.HasRoute(routeCollection, route);
        //    //routeCollection.ShouldMap(route).To<IntroductionController>( x => x.Intro());
        // }
    }
}
