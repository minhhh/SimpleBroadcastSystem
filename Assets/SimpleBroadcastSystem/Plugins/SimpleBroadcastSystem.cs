using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class SimpleBroadcastSystem
{
    protected class BroadcastEvent : UnityEvent <object>
    {
    }

    protected Dictionary<string, BroadcastEvent> subscriberLists = new Dictionary<string, BroadcastEvent> ();

    public void AddSubscriber (string eventName, UnityAction <object> callback)
    {
        BroadcastEvent unityEvent = null;
        if (!subscriberLists.TryGetValue (eventName, out unityEvent)) {
            subscriberLists [eventName] = new BroadcastEvent ();
        }
        subscriberLists [eventName].AddListener (callback);
    }

    public void RemoveSubscriber (string eventName, UnityAction <object> callback)
    {
        try {
            BroadcastEvent unityEvent = null;
            if (subscriberLists.TryGetValue (eventName, out unityEvent)) {
                unityEvent.RemoveListener (callback);
            }
        } catch (Exception e) {
            Debug.LogWarning (string.Format ("{0}::RemoveSubscriber Error {1}", this.GetType ().FullName, e.Message));
        }
    }

    public void Broadcast (string eventName, object parameter = null)
    {
        BroadcastEvent unityEvent = null;
        if (subscriberLists.TryGetValue (eventName, out unityEvent)) {
            unityEvent.Invoke (parameter);
        }
    }
}

