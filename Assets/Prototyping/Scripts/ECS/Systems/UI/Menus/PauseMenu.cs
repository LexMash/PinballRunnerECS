using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.MonoComponents.UI.Menus;
using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Systems.UI.Menus
{
    public class PauseMenu : MenuInitSystem<PauseMenuMono>
    {
        protected override void CloseButtonClicked()
        {
            Time.timeScale = 1;
            base.CloseButtonClicked();
        }

        protected override void Subscribe()
        {
            base.Subscribe();
        }
    }
}
