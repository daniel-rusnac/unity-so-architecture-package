using System;
using System.Collections.Generic;
using UnityEngine;

namespace SOArchitecture.Channels
{
    public abstract class BaseChannelSO : ScriptableObject, IStackTraceObject
    {
        private readonly List<StackTraceEntry> _stackTraces = new List<StackTraceEntry>();
        protected readonly HashSet<Action> Listeners = new HashSet<Action>();
        
        public List<StackTraceEntry> StackTraces => _stackTraces;

        public virtual void Raise()
        {
            AddStackTrace();
            foreach (Action listener in Listeners)
            {
                listener.Invoke();
            }
        }

        public void Register(Action action)
        {
            Listeners.Add(action);
        }

        public void Unregister(Action action)
        {
            Listeners.Remove(action);
        }
        
        public void AddStackTrace()
        {
#if UNITY_EDITOR
            if (SOArchitectureUtility.IsDebugMode)
                _stackTraces.Insert(0, StackTraceEntry.Create());
#endif
        }
        public void AddStackTrace(object value)
        {
#if UNITY_EDITOR
            if(SOArchitectureUtility.IsDebugMode)
                _stackTraces.Insert(0, StackTraceEntry.Create(value));
#endif
        }
    }
}