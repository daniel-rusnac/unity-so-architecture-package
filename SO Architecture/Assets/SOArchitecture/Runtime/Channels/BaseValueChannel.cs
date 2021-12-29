using System;
using System.Collections.Generic;
using UnityEngine;

namespace SOArchitecture.Channels
{
    public abstract class BaseValueChannel<T> : BaseChannelSO
    {
        [SerializeField] private T defaultValue;

        protected HashSet<Action<T>> valueListeners = new HashSet<Action<T>>();

        public override void Raise()
        {
            Raise(defaultValue);
        }

        public void Raise(T value)
        {
            AddStackTrace(value);
            foreach (Action<T> listener in valueListeners)
            {
                listener.Invoke(value);
            }

            foreach (Action listener in listeners)
            {
                listener.Invoke();
            }
        }

        public void Register(Action<T> action)
        {
            valueListeners.Add(action);
        }

        public void Unregister(Action<T> action)
        {
            valueListeners.Remove(action);
        }
    }
}