using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Configs
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "PinBallRunner/CONFIG/CameraConfig")]
    public class CameraConfig : ScriptableObject
    {
        [field: SerializeField] public Vector3 FollowOffset { get; private set; }
        [field: SerializeField] public float SmoothSpeed { get; private set; }
    }
}
