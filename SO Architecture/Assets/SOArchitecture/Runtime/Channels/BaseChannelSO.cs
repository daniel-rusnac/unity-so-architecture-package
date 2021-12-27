using System;
using System.Collections.Generic;
using UnityEngine;

namespace SOArchitecture.Channels
{
    public abstract class BaseChannelSO : ScriptableObject
    {
        protected HashSet<Action> listeners = new HashSet<Action>();

        public virtual void Raise()
        {
            foreach (Action listener in listeners)
            {
                listener.Invoke();
            }
        }

        public void Register(Action action)
        {
            listeners.Add(action);
        }

        public void Unregister(Action action)
        {
            listeners.Remove(action);
        }
    }
}