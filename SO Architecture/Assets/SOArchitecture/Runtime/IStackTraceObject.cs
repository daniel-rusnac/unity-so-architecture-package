using System.Collections.Generic;

namespace SOArchitecture
{
    public interface IStackTraceObject
    {
        List<StackTraceEntry> StackTraces { get; }

        void AddStackTrace();
        void AddStackTrace(object value);
    } 
}