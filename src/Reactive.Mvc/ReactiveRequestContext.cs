using System.Web.Mvc;

namespace Reactive.Mvc
{
    public class ReactiveRequestContext
    {
        public string Action { get; set; }
        public ActionResult Result { get; set; }
        public ViewDataDictionary ViewData { get; set; }
        public TempDataDictionary TempData { get; set; }
    }
}
