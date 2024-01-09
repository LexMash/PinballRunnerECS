using UnityEngine;

namespace PinBallRunner
{
    public struct Ball
    {
        public BallView View;
        public Transform Transform;
        public Rigidbody Rigidbody;

        public float ForwardVelocity;
        public float StrafeVelocity;
        public float DashDistance;
        public float DashTime;
        public float DashingTime;
        public float DashCoolDownTime;
    }
}
