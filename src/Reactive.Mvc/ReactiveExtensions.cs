using System;
using System.Reactive.Linq;
using System.Web.Mvc;

namespace Reactive.Mvc
{
    public static class ReactiveExtensions
    {
        public static IDisposable ToView<TResult>(this IObservable<ReactiveRequestContext> observable, Func<ReactiveRequestContext, TResult> contentSelector)
        {
            return observable
                .Subscribe(context =>
                               {
                                   context.ControllerContext.Controller.ViewData.Model =
                                       contentSelector.Invoke(context);
                                   var result = new ViewResult
                                                    {
                                                        ViewData =
                                                            context.ControllerContext.Controller.ViewData,
                                                        TempData =
                                                            context.ControllerContext.Controller.TempData,
                                                    };
                                   result.ExecuteResult(context.ControllerContext);
                               });
        }
    }
}
