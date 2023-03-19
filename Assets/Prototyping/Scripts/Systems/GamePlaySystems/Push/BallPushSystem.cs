using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Components;
using UnityEngine;

namespace PinBallRunner
{
    public class BallPushSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Ball> _ballFilter;
        private readonly EcsFilter<PushRequest> _requestFilter;      

        public void Run()
        {
            foreach(var i in _requestFilter)
            {
                ref var request = ref _requestFilter.Get1(i);

                foreach (var ii in _ballFilter)
                {
                    ref var ball = ref _ballFilter.Get1(ii);
                    ball.Rigidbody.AddForce(request.Direction, ForceMode.Impulse);                   
                }

                ref var entity = ref _requestFilter.GetEntity(i);
                entity.Del<PushRequest>();
            }
        }
    }
}
