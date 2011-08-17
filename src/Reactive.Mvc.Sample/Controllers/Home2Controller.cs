using System.Web.Mvc;

namespace Reactive.Mvc.Sample.Controllers
{
    public class Home2Controller : Controller
    {
        //
        // GET: /Home2/

        public ActionResult Index()
        {            
            return View(new Hello("Hello plain asp.net world"));
        }

    }
}
