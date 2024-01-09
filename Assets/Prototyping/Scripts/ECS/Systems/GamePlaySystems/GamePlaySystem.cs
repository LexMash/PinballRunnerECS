using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Systems.Game;

namespace PinBallRunner.Prototyping.Scripts.Systems
{
    public abstract class GamePlaySystem : GamePlaySystemBase
    {
        protected readonly EcsFilter<GamePlayState> _gamePlayStateFilter;
        protected readonly EcsFilter<GameMainMenuState> _mainMenuStateFilter;

        protected bool _canWork;

        protected override bool CanWork()
        {
            foreach(var index in _gamePlayStateFilter)
            {
                _canWork = true;
            }

            foreach(var index in _mainMenuStateFilter)
            {
                _canWork = false;
            }

            return _canWork;
        }
    }
}
