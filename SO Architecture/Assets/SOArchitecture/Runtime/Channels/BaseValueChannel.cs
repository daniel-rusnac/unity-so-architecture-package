using System;
using System.Collections.Generic;
using UnityEngine;

namespace SOArchitecture.Channels
{
    public abstract class BaseValueChannel<T> : BaseChannelSO
    {
        [Tooltip("The value that will be raised when 'Raise' button in the inspector is pressed.")]
        [SerializeField] private T _debugValue;
        [Tooltip("The last raised value.")]
        [SerializeField] private T _lastValue;

        public T LastValue => _lastValue;

        protected readonly HashSet<Action<T>> ValueListeners = new HashSet<Action<T>>();

        public override void Raise()
        {
            Raise(_debugValue);
        }

        public void Raise(T value)
        {
            AddStackTrace(value);
            foreach (Action<T> listener in ValueListeners)
            {
                listener.Invoke(value);
            }

            foreach (Action listener in Listeners)
            {
                listener.Invoke();
            }

            _lastValue = value;
        }

        public void Register(Action<T> action)
        {
            ValueListeners.Add(action);
        }

        public void Unregister(Action<T> action)
        {
            ValueListeners.Remove(action);
        }
    }
}