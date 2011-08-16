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
        [Test]
        public void Should_map_empty_to_home_index()
        {
            var builder = new TestControllerBuilder {RawUrl = "~/"};
            var controller = new ReactiveController();
            bool called = false;
            controller.Request
                .Subscribe(Observer.Create<ReactiveRequestContext>
                               (m =>
                                    {
                                        called = true;
                                        Assert.AreEqual("Index", m.Action);
                                    }));
            var requestContext = new RequestContext(builder.HttpContext, builder.RouteData);
            ((IController) controller).Execute(requestContext);
            Assert.IsTrue(called);
        }
    }
}
