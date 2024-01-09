using Leopotam.Ecs;

namespace PinBallRunner.Prototyping.Scripts.Systems.Settings
{
    public class SettingsSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<SettingsData> _filter;

        public void Init()
        {
            EcsEntity entity = _world.NewEntity();
            var data = entity.Get<SettingsData>();
            data.MusicVolume = 0;
            data.SoundVolume = 0;

            //сделать загрузку конфига и формирование меню в зависимости от кол-ва цветов
            //data.Colors = new Color[] { Color.yellow, Color.green, Color.red, Color.blue };
        }

        public void Run()
        {
            foreach(var index in _filter)
            {
                ref var settingsData = ref _filter.Get1(index);
            }
        }
    }
}
