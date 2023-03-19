using PinBallRunner;
using UnityEngine;

[CreateAssetMenu(fileName = "BallConfig", menuName = "PinBallRunner/CONFIG/BallConfig")]
public class BallConfig : ScriptableObject
{
    [field: SerializeField] public BallView View;
    [field: SerializeField] public float ForwardVelocity { get; private set; } = 0.1f;
    [field: SerializeField] public float StrafeVelocity { get; private set; } = 7f;
    [field: SerializeField] public float DashDistance { get; private set; } = 3f;
    [field: SerializeField] public float DashTime { get; private set; } = 0.2f;
    [field: SerializeField] public float DashingTime { get; private set; } = 0.2f;
    [field: SerializeField] public float DashCoolDownTime { get; private set; } = 1f;
}
