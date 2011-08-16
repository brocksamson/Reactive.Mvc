using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Linq;
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
                                  Action = "Index"
                              };

            //TODO: this seems weird -> we essentially do 1 event & throw away chain.  Is right way from Web perspective...
            _observers.ForEach(observer => observer.OnNext(context));
            _observers.ForEach(m => m.OnCompleted());
            _completed = true;
        }

        public IDisposable Subscribe(IObserver<ReactiveRequestContext> observer)
        {
            _observers.Add(observer);
            return this;
        }

        public void Dispose()
        {
            if(!_completed)
                _observers.ForEach(m => m.OnCompleted());
        }
    }
}