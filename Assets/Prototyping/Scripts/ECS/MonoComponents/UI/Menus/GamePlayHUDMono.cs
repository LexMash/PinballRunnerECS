using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PinBallRunner.Prototyping.Scripts.MonoComponents.UI.Menus
{
    public class GamePlayHUDMono : MenuBase
    {
        [field: SerializeField] public Button StartBttn { get; private set; }
        [field: SerializeField] public Button PauseBttn { get; private set; }
        [field: SerializeField] public Button PushBttn { get; private set; }
        [field: SerializeField] public Button DashBttn { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Score { get; private set; }
    }
}
