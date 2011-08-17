using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;

namespace Reactive.Mvc.Test.Rendering
{
    //again just fighting the underlying system :(.
    //[TestFixture]
    //public class When_rendering_a_view
    //{
    //    [Test]
    //    public void Should_render_a_view_result_with_correct_model()
    //    {
    //        //setting up controllers to test this is way to damned hard -> need to abstract new factory or something.
    //        var builder = new TestControllerBuilder {RawUrl = "~/"};
    //        var controller = builder.CreateController<TestController>();
    //        controller.RouteData.Values.Add("action", "index");
    //        controller.RouteData.Values.Add("controller", "Test");
    //        var contexts = new Collection<ReactiveRequestContext>
    //                           {
    //                               new ReactiveRequestContext{ControllerContext = controller.ControllerContext}
    //                           };
    //        var observable = contexts.ToObservable();

    //        var testString = "My Test String";
    //        observable.ToView(m => testString);
    //        Assert.AreEqual(testString, contexts[0].ViewData.Model);
    //    }
    //}

    //public class TestController : Controller
    //{
    //}
}
