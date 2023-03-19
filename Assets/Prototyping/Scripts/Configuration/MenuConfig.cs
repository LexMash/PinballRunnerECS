using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Configs
{
    [CreateAssetMenu(fileName = "MenuConfig", menuName = "PinBallRunner/CONFIG/MenuConfig")]
    public class MenuConfig : ScriptableObject
    {
        [field:SerializeField] public MenuBase[] Menus { get; private set; }
    }
}
