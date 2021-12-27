using SOArchitecture.Channels;
using UnityEditor;
using UnityEngine;

namespace SOArchitecture
{
    [CustomEditor(typeof(BaseChannelSO), true)]
    public class ChannelEditor : UnityEditor.Editor
    {
        private BaseChannelSO channel;

        private void OnEnable()
        {
            channel = (BaseChannelSO) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Raise"))
            {
                channel.Raise();
            }
        }
    }
}