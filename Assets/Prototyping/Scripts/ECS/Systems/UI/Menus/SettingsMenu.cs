using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.MonoComponents.UI.Menus;
using PinBallRunner.Prototyping.Scripts.Systems.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace PinBallRunner.Prototyping.Scripts.Systems.UI.Menus
{
    public class SettingsMenu : MenuInitSystem<SettingsMenuMono>
    {
        private readonly EcsFilter<SettingsData> _settingsFilter;
        private readonly EcsFilter<Ball> _ballFilter;
        
        public override void Init()
        {
            base.Init();

            foreach(var index in _settingsFilter)
            {
                ref var settings = ref _settingsFilter.Get1(index);

                settings.Colors = new Color[]
                {
                    _menu.ColorBttn1.image.color,
                    _menu.ColorBttn2.image.color,
                    _menu.ColorBttn3.image.color,
                    _menu.ColorBttn4.image.color,
                };
            }

            InitSlider(_menu.MusicSlider);
            InitSlider(_menu.SoundSlider);
        }

        protected override void Subscribe()
        {
            base.Subscribe();

            _menu.MusicSlider.onValueChanged.AddListener(MusicVolumeChanged);
            _menu.SoundSlider.onValueChanged.AddListener(SoundVolumeChanged);

            _menu.ColorBttn1.onClick.AddListener(SetColor1Clicked);
            _menu.ColorBttn2.onClick.AddListener(SetColor2Clicked);
            _menu.ColorBttn3.onClick.AddListener(SetColor3Clicked);
            _menu.ColorBttn4.onClick.AddListener(SetColor4Clicked);
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();

            _menu.MusicSlider.onValueChanged.RemoveListener(MusicVolumeChanged);
            _menu.SoundSlider.onValueChanged.RemoveListener(SoundVolumeChanged);

            _menu.ColorBttn1.onClick.RemoveListener(SetColor1Clicked);
            _menu.ColorBttn2.onClick.RemoveListener(SetColor2Clicked);
            _menu.ColorBttn3.onClick.RemoveListener(SetColor3Clicked);
            _menu.ColorBttn4.onClick.RemoveListener(SetColor4Clicked);
        }

        private void SetColor1Clicked() => SetColor(0);
        private void SetColor2Clicked() => SetColor(1);
        private void SetColor3Clicked() => SetColor(2);
        private void SetColor4Clicked() => SetColor(3);

        private void MusicVolumeChanged(float value)
        {
            foreach(var index in _settingsFilter)
            {
                ref var settingsData = ref _settingsFilter.Get1(index);
                settingsData.MusicVolume = value;
            }
        }

        private void SoundVolumeChanged(float value)
        {
            foreach (var index in _settingsFilter)
            {
                ref var settingsData = ref _settingsFilter.Get1(index);
                settingsData.SoundVolume = value;
            }
        }

        private void SetColor(int index)
        {
            foreach (var i in _ballFilter)
            {
                foreach (var ii in _settingsFilter)
                {
                    ref var settingsData = ref _settingsFilter.Get1(ii);
                    var color = settingsData.Colors[index];

                    ref var ball = ref _ballFilter.Get1(i);
                    ball.View.Material.color = color;
                }
            }
        }

        private void InitSlider(Slider slider, float maxValue = 0, float minValue = -80)
        {
            slider.maxValue = maxValue;
            slider.minValue = minValue;
        }
    }
}
