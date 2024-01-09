using Leopotam.Ecs;
using UnityEngine;
using PinBallRunner.Prototyping.Scripts.Configs;
using PinBallRunner.Prototyping.Scripts.Systems;
using PinBallRunner.Prototyping.Scripts.Systems.UI;
using PinBallRunner.Prototyping.Scripts.Systems.Game;
using PinBallRunner.Prototyping.Scripts.Systems.Input;
using PinBallRunner.Prototyping.Scripts.Systems.Score;
using PinBallRunner.Prototyping.Scripts.Systems.Settings;
using PinBallRunner.Prototyping.Scripts.Systems.Tracking;
using PinBallRunner.Prototyping.Scripts.Systems.UI.Menus;
using PinBallRunner.Prototyping.Scripts.Systems.GamePlaySystems.Push;
using PinBallRunner.Prototyping.Scripts.MonoComponents.GameEnviroment;
using PinBallRunner.Prototyping.Scripts.Systems.Level;

namespace PinBallRunner.Prototyping.Scripts
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private SceneData _sceneData;
        private BallConfig _ballData;
        private CameraConfig _cameraData;
        private MenuConfig _menuData;
        private LevelGeneratorData _levelGeneratorData;

        private EcsWorld _world;
        private EcsSystems _fixedUpdateSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _lateUpdateSystems;

        private GameInput _input;

        private async void Start()
        {
            _ballData = await AssetLoader.LoadAsync<BallConfig>("BallConfig");
            _cameraData = await AssetLoader.LoadAsync<CameraConfig>("CameraConfig");
            _menuData = await AssetLoader.LoadAsync<MenuConfig>("MenuData");
            _levelGeneratorData = await AssetLoader.LoadAsync<LevelGeneratorData>("LevelGeneratorData");

            _input = new GameInput();
            _input.Enable();

            _world = new EcsWorld();
            _fixedUpdateSystems = new EcsSystems(_world, "FIXED");
            _updateSystems = new EcsSystems(_world, "UPDATE");
            _lateUpdateSystems = new EcsSystems(_world, "LATE");

            _fixedUpdateSystems
                .Inject(_sceneData)
                .Inject(_ballData)
                .Inject(_levelGeneratorData)

                .Add(new GameStateSystem())
                .Add(new SettingsSystem())

                .Add(new BallInitSystem())
                .Add(new LevelGeneratorSystem())
                .Add(new BallMovementSystem())

                .Add(new BallPushSystem())
                .Add(new BallDashSystem())
                .Add(new BallDistanceTrackingSystem())
                ;

            _updateSystems
                .Inject(_input)
                .Inject(_sceneData)
                .Inject(_ballData)
                .Inject(_menuData)

                .Add(new InterfaceSystem())
                .Add(new PauseMenu())

                .Add(new PushInputReceiver())
                .Add(new DashInputReceiver())

                .Add(new ScoreSystem())
                .Add(new GamePlayHUD())
                .Add(new PlayerPushRequestHandler())
                .Add(new DashCooldownSystem())
                .Add(new MainMenu())
                .Add(new SettingsMenu())

                ;

            _lateUpdateSystems
                .Inject(_sceneData)
                .Inject(_cameraData)

                .Add(new CameraFollowSystem())              
                ;

            _fixedUpdateSystems.Init();
            _updateSystems.Init();
            _lateUpdateSystems.Init();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void Update()
        {
            _updateSystems?.Run();
        }

        private void LateUpdate()
        {
            _lateUpdateSystems?.Run();
        }

        private void OnDestroy()
        {
            AssetLoader.Unload(_ballData);
            AssetLoader.Unload(_cameraData);
            AssetLoader.Unload(_menuData);
            AssetLoader.Unload(_levelGeneratorData);

            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;

            _updateSystems?.Destroy();
            _updateSystems = null;

            _lateUpdateSystems?.Destroy();
            _updateSystems = null;

            _world?.Destroy();
            _world = null;
        }
    }
}
