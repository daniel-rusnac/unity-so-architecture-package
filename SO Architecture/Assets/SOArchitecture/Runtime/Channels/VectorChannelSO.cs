using UnityEngine;

namespace SOArchitecture.Channels
{
    [CreateAssetMenu(fileName = "Vector Channel", menuName = Utility.CHANNEL_CREATION_MENU + "Vector Channel")]
    public class VectorChannelSO : BaseValueChannel<Vector4> { }
}