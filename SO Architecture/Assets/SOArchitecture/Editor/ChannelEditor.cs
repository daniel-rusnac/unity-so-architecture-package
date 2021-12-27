using TryMyGames.SOArchitecture.Channels;
using UnityEditor;
using UnityEngine;

namespace TryMyGames.SOArchitecture
{
    [CustomEditor(typeof(BaseChannelSO), true)]
    public class ChannelEditor : Editor
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