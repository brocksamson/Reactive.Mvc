using System.Reactive.Linq;

namespace Reactive.Mvc.Sample.Controllers
{
    public class HomeController : ReactiveController
    {
        public HomeController()
        {
            Request
                .Where(m => m.Action.ToLower() == "index")
                .ToView(select => new Hello("Hello Reactive World!"));
            Request
                .Where(m => m.Action.ToLower() == "indexjson")
                //.Where(m => m.Action.ToLower() == "index" && m.ControllerContext.HttpContext.Request.ContentType.ToLower().Contains("json"))
                .ToJson(select => new Hello("Hello Reactive World!"));

            //better form -> setup UI convention -> this works for both of the above simple setups.
            //Request
            //    .Where(m => m.Action.ToLower() == "index")
            //    .Render(select => new Hello("Hello Reactive World!"));
            //render checks ContentType & then delegates to ToJson if necessary.
        }
    }

    public class Hello
    {
        public string HelloWorld { get; private set; }

        public Hello(string helloWorld)
        {
            HelloWorld = helloWorld;
        }
    }
}