using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace so_events
{
    [CreateAssetMenu]
    public class Event : ScriptableObject
    {
        List<EventListener> _listeners = new List<EventListener>();

        public void Raise()
        {
            for (var i = _listeners.Count - 1; i >= 0 ; --i)
            {
                _listeners[i].OnEventRaised();
            }
        }

        public void Register(EventListener listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(EventListener listener)
        {
            _listeners.Remove(listener);
        }
    }

    public class Event<TArg> : ScriptableObject
    {
        List<EventListener<TArg>> _listeners = new List<EventListener<TArg>>();

        public void Raise(TArg arg)
        {
            for (var i = _listeners.Count - 1; i >= 0 ; --i)
            {
                _listeners[i].OnEventRaised(arg);
            }
        }

        public void Register(EventListener<TArg> listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(EventListener<TArg> listener)
        {
            _listeners.Remove(listener);
        }
    }
}