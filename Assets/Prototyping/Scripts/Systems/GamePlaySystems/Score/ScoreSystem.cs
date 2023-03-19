using Leopotam.Ecs;

namespace PinBallRunner.Prototyping.Scripts.Systems.Score
{
    public class ScoreSystem : IEcsInitSystem, IEcsRunSystem
    {
        private protected EcsWorld _world;
        private EcsEntity _data;
        private protected EcsFilter<ScoreCollectRequest> _scoreRequestFilter;

        public void Init()
        {
            _data = _world.NewEntity();
            _data.Get<GameScore>();
        }

        public void Run()
        {
            foreach(var index in _scoreRequestFilter)
            {
                ref var entity = ref _scoreRequestFilter.GetEntity(index);
                _data.Get<GameScore>().Value += entity.Get<ScoreCollectRequest>().Value;

                entity.Get<GameScoreChangedEvent>();
                entity.Del<ScoreCollectRequest>();
            }
        }
    }
}
