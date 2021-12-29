using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SOArchitecture
{
    public class StackTraceEntry : IEquatable<StackTraceEntry>
    {
        private StackTraceEntry(string trace)
        {
            id = Random.Range(int.MinValue, int.MaxValue);
            stackTrace = trace;

            if (Application.isPlaying)
            {
                time = Time.time;
            }
        }

        private StackTraceEntry(string trace, object value)
        {
            this.value = value;
            constructedWithValue = true;
            id = Random.Range(int.MinValue, int.MaxValue);
            stackTrace = trace;

            if (Application.isPlaying)
            {
                time = Time.time;
            }
        }

        private readonly int id;
        private readonly float time;
        private readonly string stackTrace;
        private readonly object value;
        private readonly bool constructedWithValue;

        public static StackTraceEntry Create(object obj)
        {
            return new StackTraceEntry(Environment.StackTrace, obj);
        }

        public static StackTraceEntry Create()
        {
            return new StackTraceEntry(Environment.StackTrace);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is StackTraceEntry)
            {
                return Equals(obj as StackTraceEntry);
            }

            return false;
        }

        public bool Equals(StackTraceEntry other)
        {
            return other.id == id;
        }

        public override int GetHashCode()
        {
            return id;
        }

        public override string ToString()
        {
            if (constructedWithValue)
            {
                return string.Format("[{1}] [{0}] {2}", value == null ? "null" : value.ToString(), TimeSpan.FromSeconds(time).ToString(@"hh\:mm\:ss"),
                    stackTrace);
            }
            else
            {
                return string.Format("[{0}] {1}", TimeSpan.FromSeconds(time).ToString(@"hh\:mm\:ss"), stackTrace);
            }
        }

        public static implicit operator string(StackTraceEntry trace)
        {
            return trace.ToString();
        }
    }
}