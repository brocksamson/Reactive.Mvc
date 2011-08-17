using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;

namespace Reactive.Mvc.Test.Rendering
{
    //again just fighting the underlying system :(.
    [TestFixture]
    public class When_rendering_a_view
    {
        private IObservable<ReactiveRequestContext> _observable;

        [Test]
        public void Should_render_a_view_result_with_correct_model()
        {
            var contexts = new Collection<ReactiveRequestContext>
                               {
                                   new ReactiveRequestContext{ViewData = new ViewDataDictionary()}
                               };
            _observable = contexts.ToObservable();

            const string testString = "My Test String";
            _observable.ToView(m => testString);
            Assert.AreEqual(testString, contexts[0].ViewData.Model);
        }

        [Test]
        public void Should_render_a_json_result_with_correct_model()
        {
            var contexts = new Collection<ReactiveRequestContext>
                               {
                                   new ReactiveRequestContext{ViewData = new ViewDataDictionary()}
                               };
            var observable = contexts.ToObservable();

            const string testString = "My Test String";
            observable.ToJson(m => testString);
            Assert.AreEqual(testString, contexts[0].ViewData.Model);
        }
    }
}
