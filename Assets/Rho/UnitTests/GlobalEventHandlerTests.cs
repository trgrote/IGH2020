using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using rho;

namespace Tests
{
    public class GlobalEventHandlerTests
    {
        #region Test Data Types

        internal class TestEvent : IGameEvent
        {
        }

        internal class EventTestBehavior : MonoBehaviour
        {
            public System.Action<TestEvent> Callback;
            public System.Action<IGameEvent> AnyCallback;

            public void OnTestEvent(TestEvent testEvent)
            {
                Callback?.Invoke(testEvent);
            }

            public void OnAnyEvent(IGameEvent testEvent)
            {
                AnyCallback?.Invoke(testEvent);
            }
        }

        #endregion

        #region Setup / Teardowns

        [TearDown]
        public void ClearAllEventRegisters()
        {
            rho.GlobalEventHandler.Clear();
        }

        #endregion

        #region Tests

        // A Test behaves as an ordinary method
        [Test]
        public void RegisteredCallbackIsCalled()
        {
            // Make new game object that just exists to have an eventtest behvior on it
            var eventTester = new GameObject().AddComponent<EventTestBehavior>();
            bool evtCalled = false;

            eventTester.Callback = (evt) =>
            {
                evtCalled = true;
            };

            rho.GlobalEventHandler.Register<TestEvent>(eventTester.OnTestEvent);
            rho.GlobalEventHandler.SendEvent(new TestEvent());

            Assert.IsTrue(evtCalled);
        }

        [Test]
        public void UnregisterDoesntCall()
        {
            // Make new game object that just exists to have an eventtest behvior on it
            var eventTester = new GameObject().AddComponent<EventTestBehavior>();
            bool evtCalled = false;

            eventTester.Callback = (evt) =>
            {
                evtCalled = true;
            };

            rho.GlobalEventHandler.Register<TestEvent>(eventTester.OnTestEvent);
            rho.GlobalEventHandler.Unregister<TestEvent>(eventTester.OnTestEvent);
            rho.GlobalEventHandler.SendEvent(new TestEvent());

            Assert.IsFalse(evtCalled);
        }

        // I was only able to get Debugger Working if I made it a UnityTest with IEnumerator return
        [UnityTest]
        public IEnumerator RegisteredAllCallbackIsCalled()
        {
            // Make new game object that just exists to have an eventtest behvior on it
            var eventTester = new GameObject().AddComponent<EventTestBehavior>();
            bool evtCalled = false;

            eventTester.AnyCallback = (evt) =>
            {
                evtCalled = true;
            };

            rho.GlobalEventHandler.RegisterAll(eventTester.OnAnyEvent);
            rho.GlobalEventHandler.SendEvent(new TestEvent());

            Assert.IsTrue(evtCalled);

            yield return null;
        }

        [Test]
        public void UnregisteredAllDoesntCall()
        {
            // Make new game object that just exists to have an eventtest behvior on it
            var eventTester = new GameObject().AddComponent<EventTestBehavior>();
            bool evtCalled = false;

            eventTester.Callback = (evt) =>
            {
                evtCalled = true;
            };

            rho.GlobalEventHandler.RegisterAll(eventTester.OnAnyEvent);
            rho.GlobalEventHandler.UnregisterAll(eventTester.OnAnyEvent);
            rho.GlobalEventHandler.SendEvent(new TestEvent());

            Assert.IsFalse(evtCalled);
        }

        [UnityTest]
        public IEnumerator RegisteredAllCallbackIsCalledAndTypeIsChecked()
        {
            // Make new game object that just exists to have an eventtest behvior on it
            var eventTester = new GameObject().AddComponent<EventTestBehavior>();
            bool evtCalled = false;

            eventTester.AnyCallback = (evt) =>
            {
                if (evt is TestEvent)
                {
                    evtCalled = true;
                }
            };

            rho.GlobalEventHandler.RegisterAll(eventTester.OnAnyEvent);
            rho.GlobalEventHandler.SendEvent(new TestEvent());

            Assert.IsTrue(evtCalled);

            yield return null;
        }

        #endregion
    }
}
