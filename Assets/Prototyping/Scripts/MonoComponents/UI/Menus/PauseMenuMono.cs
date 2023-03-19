using UnityEngine;
using UnityEngine.UI;

namespace PinBallRunner.Prototyping.Scripts.MonoComponents.UI.Menus
{
    public class PauseMenuMono : MenuBase
    {
        [field: SerializeField] public Button MainMenuBttn { get; private set; }
        [field: SerializeField] public Button SettingsBttn { get; private set; }
    }
}
