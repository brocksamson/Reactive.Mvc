using System;
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
                                   var viewData = context.ControllerContext.Controller.ViewData;
                                   viewData.Model = contentSelector.Invoke(context);
                                   var result = new ViewResult
                                                    {
                                                        ViewData = viewData,
                                                        TempData = context.ControllerContext.Controller.TempData,
                                                    };
                                   result.ExecuteResult(context.ControllerContext);
                               });
        }
        
        public static IDisposable ToJson<TResult>(this IObservable<ReactiveRequestContext> observable, Func<ReactiveRequestContext, TResult> contentSelector)
        {
            return observable
                .Subscribe(context =>
                               {
                                   context.ControllerContext.Controller.ViewData.Model = contentSelector.Invoke(context);
                                   var result = new JsonResult
                                                    {
                                                        Data = contentSelector.Invoke(context),
                                                        ContentType = null,
                                                        ContentEncoding = null,
                                                        JsonRequestBehavior = JsonRequestBehavior.DenyGet
                                                    };
                                   result.ExecuteResult(context.ControllerContext);
                               });
        }
    }
}
