using System.Web.Mvc;

namespace Reactive.Mvc
{
    public class ReactiveRequestContext
    {
        public string Action { get; set; }
        public ControllerContext ControllerContext { get; set; }
    }
}
