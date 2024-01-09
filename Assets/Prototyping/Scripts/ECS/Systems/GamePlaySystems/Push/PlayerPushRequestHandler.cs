using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Components;
using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Systems.GamePlaySystems.Push
{
    public class PlayerPushRequestHandler : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<PlayerPushRequest> _requestFilter;
        private readonly EcsFilter<Ball> _ballFilter;
        private int _directionModificator;

        public void Init()
        {
            var indexArray = new int[] { -1, 1, 2 };
            _directionModificator = indexArray[Random.Range(0, 2)];
        }

        public void Run()
        {
            foreach (var i in _requestFilter)
            {
                foreach (var ii in _ballFilter)
                {
                    ref var ball = ref _ballFilter.Get1(ii);
                    _directionModificator *= -1;
                    var direction = Vector3.right * _directionModificator * ball.StrafeVelocity;

                    _world.NewEntity().Get<PushRequest>().Direction = direction;
                }

                ref var entity = ref _requestFilter.GetEntity(i);
                entity.Del<PlayerPushRequest>();
            }
        }
    }
}
