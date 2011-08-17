using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Web.Mvc;

namespace Reactive.Mvc.Sample.Controllers
{
    public class HomeController : ReactiveController
    {
        public HomeController()
        {
            Request
                //simplest ways first :)
                .Where(m => m.Action.ToLower() == "index")
                .ToView(select => new Hello("Hello World"));
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