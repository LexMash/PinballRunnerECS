using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Configs;
using UnityEngine;

namespace PinBallRunner
{
    public class BallInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        private readonly BallConfig _ballConfig;
        private readonly SceneData _sceneData;

        public void Init()
        {
            EcsEntity entity = _world.NewEntity();

            ref var ball = ref entity.Get<Ball>();

            var ballGO = Object.Instantiate(_ballConfig.View, _sceneData.SpawnPoint.position, Quaternion.identity);

            ball.View = ballGO;
            ball.Rigidbody = ballGO.GetComponent<Rigidbody>();
            
            ball.Transform = ballGO.transform;
            ball.ForwardVelocity = _ballConfig.ForwardVelocity;
            ball.StrafeVelocity = _ballConfig.StrafeVelocity;
            ball.DashTime = _ballConfig.DashTime;
            ball.DashDistance = _ballConfig.DashDistance;
            ball.DashingTime = _ballConfig.DashingTime;
            ball.DashCoolDownTime = _ballConfig.DashCoolDownTime;

            var ballView = ballGO.GetComponent<BallView>();
            ballView.Entity = entity;
        }
    }
}
