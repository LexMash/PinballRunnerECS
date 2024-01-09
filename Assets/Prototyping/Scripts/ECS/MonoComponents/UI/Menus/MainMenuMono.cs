using UnityEngine;
using UnityEngine.UI;

namespace PinBallRunner.Prototyping.Scripts.MonoComponents.UI.Menus
{
    public class MainMenuMono : MenuBase
    {
        [field:SerializeField] public Button PlayBttn { get; private set; }
        [field:SerializeField] public Button SettingsBttn { get; private set; }
        [field:SerializeField] public Button LeadersBttn { get; private set; }
        [field:SerializeField] public Button HowToBttn { get; private set; }
    }
}
