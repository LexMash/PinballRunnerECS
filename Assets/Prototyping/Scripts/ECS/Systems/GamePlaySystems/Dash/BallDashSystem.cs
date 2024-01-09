using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Components;
using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Systems
{
    public class BallDashSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Ball>.Exclude<DashCooldown> _ballFilter;
        private readonly EcsFilter<DashRequest> _requestFilter;

        public void Run()
        {
            foreach(var i in _requestFilter)
            {
                ref var request = ref _requestFilter.GetEntity(i);

                foreach (var ii in _ballFilter)
                {
                    ref var ball = ref _ballFilter.Get1(ii);

                    var dashPower = ball.DashDistance / ball.DashTime;

                    ball.Rigidbody.AddForce(Vector3.forward * dashPower, ForceMode.Impulse);

                    ref var ballEntity = ref _ballFilter.GetEntity(i);
                    ballEntity.Get<DashCooldown>().Time = ball.DashCoolDownTime;
                }

                request.Del<DashRequest>();
            }
        }
    }
}
