using UnityEngine;

namespace SOArchitecture
{
    internal static class SOArchitectureUtility
    {
        public const string CHANNEL_CREATION_MENU = "Channels/";

        public static bool IsDebugMode => Application.isEditor;
    }
}