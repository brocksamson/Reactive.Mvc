using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Reactive.Mvc
{
    public class ReactiveController : ControllerBase, IObservable<ReactiveRequestContext>, IDisposable
    {
        //this will probably need to be a bit more robust
        private List<IObserver<ReactiveRequestContext>> _observers;
        private bool _completed;

        public ReactiveController()
        {
            _observers = new List<IObserver<ReactiveRequestContext>>();
            _completed = false;
        }

        public IObservable<ReactiveRequestContext> Request { get { return this; } }
        protected override void ExecuteCore()
        {
            var context = new ReactiveRequestContext()
                              {
                                  Action = ResolveAction(),
                                  ViewData = ViewData,
                                  TempData = TempData
                              };

            //TODO: this seems weird -> we essentially do 1 event & throw away chain.  Is right way from Web lifecycle...
            //robust imp would setup a singleton observer of some sort & let the IOC container determine lifecycle of observers :)
            _observers.ForEach(observer => observer.OnNext(context));
            _completed = true;
            _observers.ForEach(m => m.OnCompleted());
            context.Result.ExecuteResult(ControllerContext);
        }

        private string ResolveAction()
        {
            return ControllerContext.RouteData.GetRequiredString("action");
        }

        public IDisposable Subscribe(IObserver<ReactiveRequestContext> observer)
        {
            _observers.Add(observer);
            return this;
        }

        public void Dispose()
        {
            //so uncommenting this swallows all errors in the pipeline or makes them internal errors
            //if(!_completed)
            //    _observers.ForEach(m => m.OnError(new ObjectDisposedException("Dispose was called before complete.")));
        }
    }
}
