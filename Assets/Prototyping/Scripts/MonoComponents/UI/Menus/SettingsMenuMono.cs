using UnityEngine;
using UnityEngine.UI;

namespace PinBallRunner.Prototyping.Scripts.MonoComponents.UI.Menus
{
    public class SettingsMenuMono : MenuBase
    {
        [field: SerializeField] public Slider MusicSlider { get; private set; }
        [field: SerializeField] public Slider SoundSlider { get; private set; }
        [field: SerializeField] public Button ColorBttn1 { get; private set; }
        [field: SerializeField] public Button ColorBttn2 { get; private set; }
        [field: SerializeField] public Button ColorBttn3 { get; private set; }
        [field: SerializeField] public Button ColorBttn4 { get; private set; }
    }
}
