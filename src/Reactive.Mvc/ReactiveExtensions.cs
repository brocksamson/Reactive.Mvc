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
                                   var viewData = context.ViewData;
                                   viewData.Model = contentSelector.Invoke(context);
                                   var result = new ViewResult
                                                    {
                                                        ViewData = viewData,
                                                        TempData = context.TempData
                                                    };
                                   context.Result = result;
                               });
        }
        
        public static IDisposable ToJson<TResult>(this IObservable<ReactiveRequestContext> observable, Func<ReactiveRequestContext, TResult> contentSelector)
        {
            return observable
                .Subscribe(context =>
                               {
                                   context.ViewData.Model = contentSelector.Invoke(context);
                                   var result = new JsonResult
                                                    {
                                                        Data = contentSelector.Invoke(context),
                                                        ContentType = null,
                                                        ContentEncoding = null,
                                                        JsonRequestBehavior = JsonRequestBehavior.DenyGet
                                                    };
                                   context.Result = result;
                               });
        }
    }
}
