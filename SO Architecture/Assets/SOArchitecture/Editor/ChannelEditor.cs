using SOArchitecture.Channels;
using UnityEditor;
using UnityEngine;

namespace SOArchitecture
{
    [CustomEditor(typeof(BaseChannelSO), true)]
    public class ChannelEditor : Editor
    {
        private StackTrace stackTrace;
        private BaseChannelSO channel;

        private void OnEnable()
        {
            channel = (BaseChannelSO) target;
            stackTrace = new StackTrace(channel);
            stackTrace.OnRepaint.AddListener(Repaint);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Raise"))
            {
                channel.Raise();
            }

            stackTrace.Draw();
        }
    }
}