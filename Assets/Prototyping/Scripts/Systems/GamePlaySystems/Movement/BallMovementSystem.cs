using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Systems;
using UnityEngine;

namespace PinBallRunner
{
    public class BallMovementSystem : GamePlaySystem
    {
        private readonly EcsFilter<Ball> _filter;

        public override void Run()
        {
            base.Run();

            if (!CanWork())
            {
                return;
            }

            foreach (var index in _filter)
            {              
                ref var ball = ref _filter.Get1(index);

                ball.Rigidbody.AddForce(Vector3.forward * ball.ForwardVelocity, ForceMode.VelocityChange);
            }
        }
    }
}
