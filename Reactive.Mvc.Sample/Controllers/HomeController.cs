using System.Reactive.Linq;
using System.Web.Mvc;

namespace Reactive.Mvc.Sample.Controllers
{
    public class HomeController : ReactiveController
    {
        public HomeController()
        {
            //Request
            //    .Where(m => m.Action == "index")
                //.View("Hi world");
        }
    }
}
