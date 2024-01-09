using Leopotam.Ecs;

namespace PinBallRunner.Prototyping.Scripts.Systems.Game
{
    public class GameStateSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world;

        private readonly EcsFilter<SetGamePlayStateRequest> _playRequestFilter;
        private readonly EcsFilter<SetGameMainMenuRequest> _mainMenuRequestFilter;

        private readonly EcsFilter<GameMainMenuState> _mainStateFilter;
        private readonly EcsFilter<GamePlayState> _playStateFilter;

        private bool _isPaused;

        public void PreInit()
        {
            _world.NewEntity().Get<GameMainMenuState>();

            _isPaused = true;
        }

        public void Run()
        {
            ClearEvents();

            HandlePlayRequest();
            MainMenuRequest();
        }

        private void ClearEvents()
        {
            foreach(var index in _mainStateFilter)
            {
                ref var entity = ref _mainStateFilter.GetEntity(index);
                entity.Del<GameMainMenuState>();
            }

            foreach (var index in _playStateFilter)
            {
                ref var entity = ref _playStateFilter.GetEntity(index);
                entity.Del<GamePlayState>();
            }
        }

        private void HandlePlayRequest()
        {
            foreach (var index in _playRequestFilter)
            {             
                ref var playRequestContainer = ref _playRequestFilter.GetEntity(index);

                if (_isPaused)
                {                 
                    _isPaused = false;

                    playRequestContainer.Get<GamePlayState>();
                }

                playRequestContainer.Del<SetGamePlayStateRequest>();
            }
        }      

        private void MainMenuRequest()
        {
            foreach (var index in _mainMenuRequestFilter)
            {
                ref var mainManuRequestContainer = ref _mainMenuRequestFilter.GetEntity(index);

                if (!_isPaused)
                {
                    _isPaused = true;

                    mainManuRequestContainer.Get<GameMainMenuState>();
                }

                mainManuRequestContainer.Del<SetGameMainMenuRequest>();
            }
        }
    }
}
