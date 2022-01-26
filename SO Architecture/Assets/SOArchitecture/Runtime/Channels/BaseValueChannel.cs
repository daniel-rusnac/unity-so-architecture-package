using System;
using System.Collections.Generic;
using UnityEngine;

namespace SOArchitecture.Channels
{
    public abstract class BaseValueChannel<T> : BaseChannelSO
    {
        [SerializeField] private T _defaultValue;

        public T LastValue { get; private set; } = default;

        protected HashSet<Action<T>> valueListeners = new HashSet<Action<T>>();

        public override void Raise()
        {
            Raise(_defaultValue);
        }

        public void Raise(T value)
        {
            AddStackTrace(value);
            foreach (Action<T> listener in valueListeners)
            {
                listener.Invoke(value);
            }

            foreach (Action listener in Listeners)
            {
                listener.Invoke();
            }

            LastValue = value;
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