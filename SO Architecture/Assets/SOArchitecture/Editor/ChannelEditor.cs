using SOArchitecture.Channels;
using UnityEditor;
using UnityEngine;

namespace SOArchitecture
{
    [CustomEditor(typeof(BaseChannelSO), true)]
    public class ChannelEditor : Editor
    {
        private StackTrace _stackTrace;
        private BaseChannelSO _channel;

        private void OnEnable()
        {
            _channel = (BaseChannelSO) target;
            _stackTrace = new StackTrace(_channel);
            _stackTrace.OnRepaint.AddListener(Repaint);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            GUI.enabled = Application.isPlaying;

            if (GUILayout.Button("Raise"))
            {
                _channel.Raise();
            }
            
            GUI.enabled = true;

            if (!Application.isPlaying)
            {
                EditorGUILayout.HelpBox("Raise is available only during play mode!", MessageType.Info);
            }
            
            _stackTrace.Draw();
        }
    }
}