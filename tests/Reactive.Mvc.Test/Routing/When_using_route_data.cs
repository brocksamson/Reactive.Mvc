using System.Reactive;
using System.Web.Mvc;
using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;

namespace Reactive.Mvc.Test.Routing
{
    [TestFixture]
    public class When_using_route_data
    {
        //Am testing the framework, not my code...
        //private RouteCollection _routes;

        //[SetUp]
        //public void Arrange()
        //{
        //    _routes = new RouteCollection();
        //    _routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        //    _routes.MapRoute(
        //        "Default", // Route name
        //        "{controller}/{action}/{id}", // URL with parameters
        //        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
        //    );
        //}
        //[Test]
        //public void Should_map_empty_to_home_index()
        //{
        //    var builder = new TestControllerBuilder {RawUrl = "~/"};            
        //    var controller = new ReactiveController();
        //    bool called = false;
        //    controller.Request
        //        .Subscribe(Observer.Create<ReactiveRequestContext>
        //                       (m =>
        //                            {
        //                                called = true;
        //                                Assert.AreEqual("Index", m.Action);
        //                            }));
        //    var requestContext = new RequestContext(builder.HttpContext, builder.RouteData);
        //    ((IController) controller).Execute(requestContext);
        //    Assert.IsTrue(called);
        //}        
        
        //[Test]
        //public void Should_map_edit_to_edit()
        //{
        //    var builder = new TestControllerBuilder {RawUrl = "~/Edit"};
        //    var controller = new ReactiveController();
        //    bool called = false;
        //    controller.Request
        //        .Subscribe(Observer.Create<ReactiveRequestContext>
        //                       (m =>
        //                            {
        //                                called = true;
        //                                Assert.AreEqual("Edit", m.Action);
        //                            }));
        //    var requestContext = new RequestContext(builder.HttpContext, builder.RouteData);
        //    ((IController) controller).Execute(requestContext);
        //    Assert.IsTrue(called);
        //}
    }
}
