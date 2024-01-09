using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.MonoComponents.UI.Menus;
using System;

namespace PinBallRunner.Prototyping.Scripts.Systems.UI.Menus
{
    public class MainMenu : MenuInitSystem<MainMenuMono>
    {
        protected override void Subscribe()
        {
            base.Subscribe();

            _menu.PlayBttn.onClick.AddListener(PlayBttnClicked);
            _menu.SettingsBttn.onClick.AddListener(SettingsBttnClicked);
            _menu.LeadersBttn.onClick.AddListener(LeadersBttnClicked);
            _menu.HowToBttn.onClick.AddListener(HowToBttnClicked);
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();

            _menu.PlayBttn.onClick.RemoveListener(PlayBttnClicked);
            _menu.SettingsBttn.onClick.RemoveListener(SettingsBttnClicked);
            _menu.LeadersBttn.onClick.RemoveListener(LeadersBttnClicked);
            _menu.HowToBttn.onClick.RemoveListener(HowToBttnClicked);
        }

        private void PlayBttnClicked()
        {
            SendRequest(typeof(GamePlayHUDMono));
        }

        private void SettingsBttnClicked()
        {
            SendRequest(typeof(SettingsMenuMono));
        }

        private void LeadersBttnClicked()
        {
            //SendRequest(typeof(SettingsMenuMono));
        }

        private void HowToBttnClicked()
        {
            //SendRequest(typeof(SettingsMenuMono));
        }

        private void SendRequest(Type type)
        {
            EcsEntity entity = _world.NewEntity();
            entity.Get<MenuOpenRequest>().MenuType = type;
        }
    }
}
