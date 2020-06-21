using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace so_events
{
    public class EventListener : MonoBehaviour
    {
        public Event Event;
        public UnityEvent Response;

        void OnEnable()
        {
            Event.Register(this);
        }

        void OnDisable()
        {
            Event.Unregister(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }

    public class EventListener<TArg> : MonoBehaviour
    {
        public Event<TArg> Event;
        public UnityEvent<TArg> Response;

        void OnEnable()
        {
            Event.Register(this);
        }

        void OnDisable()
        {
            Event.Unregister(this);
        }

        public void OnEventRaised(TArg arg)
        {
            Response.Invoke(arg);
        }
    }
}