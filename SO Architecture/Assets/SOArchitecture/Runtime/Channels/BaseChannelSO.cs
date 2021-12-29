using System;
using System.Collections.Generic;
using UnityEngine;

namespace SOArchitecture.Channels
{
    public abstract class BaseChannelSO : ScriptableObject, IStackTraceObject
    {
        private List<StackTraceEntry> stackTraces = new List<StackTraceEntry>();
        protected HashSet<Action> listeners = new HashSet<Action>();
        
        public List<StackTraceEntry> StackTraces => stackTraces;

        public virtual void Raise()
        {
            AddStackTrace();
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
        
        public void AddStackTrace()
        {
#if UNITY_EDITOR
            if (SOArchitectureUtility.IsDebugMode)
                stackTraces.Insert(0, StackTraceEntry.Create());
#endif
        }
        public void AddStackTrace(object value)
        {
#if UNITY_EDITOR
            if(SOArchitectureUtility.IsDebugMode)
                stackTraces.Insert(0, StackTraceEntry.Create(value));
#endif
        }
    }
}