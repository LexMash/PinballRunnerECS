using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Systems.Score;
using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Systems.Tracking
{
    public class BallDistanceTrackingSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<Ball> _filter;
        private EcsEntity _trackingData;
        private Vector3 _startPosition;   

        public void Init()
        {
            _trackingData = _world.NewEntity();
            _trackingData.Get<BallTrackingData>();

            foreach(var index in  _filter)
            {
                ref var ball = ref _filter.Get1(index);
                _startPosition = ball.View.transform.position;
            }           
        }

        public void Run()
        {
            foreach(var index in _filter)
            {
                ref var ball = ref _filter.Get1(index);

                var currentDistance = Vector3.Distance(_startPosition, ball.View.transform.position);
                var cashedDistance = _trackingData.Get<BallTrackingData>().Distance;

                if (currentDistance - cashedDistance > 1 && currentDistance > cashedDistance)
                {
                    _world.NewEntity().Get<ScoreCollectRequest>().Value = 1; //сделать загрузку конфига очков
                    _trackingData.Get<BallTrackingData>().Distance = currentDistance;
                }      
            }
        }
    }
}