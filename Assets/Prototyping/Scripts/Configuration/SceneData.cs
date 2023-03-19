using PinBallRunner.Prototyping.Scripts.MonoComponents.UI;
using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Configs
{
    public class SceneData : MonoBehaviour
    {
        [field: SerializeField] public Camera MainCamera { get; private set; }
        [field: SerializeField] public Transform SpawnPoint { get; private set; }
        [field: SerializeField] public MenuContainer MenuContainer { get; private set; }
    }
}
