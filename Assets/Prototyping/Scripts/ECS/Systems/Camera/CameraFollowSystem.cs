using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Configs;
using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Systems
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData;
        private readonly CameraConfig _cameraData;

        private readonly EcsFilter<Ball> _filter;

        private Vector3 _currentVelocity;

        public void Run()
        {
            foreach(var index in _filter)
            {
                ref var ball = ref _filter.Get1(index);
                var cameraCurrentPosition = _sceneData.MainCamera.transform.position;
                var target = new Vector3(cameraCurrentPosition.x, cameraCurrentPosition.y, ball.Transform.position.z);
                cameraCurrentPosition = Vector3.SmoothDamp(cameraCurrentPosition, target + _cameraData.FollowOffset, ref _currentVelocity, _cameraData.SmoothSpeed);
                _sceneData.MainCamera.transform.position = cameraCurrentPosition;
            }
        }
    }
}
