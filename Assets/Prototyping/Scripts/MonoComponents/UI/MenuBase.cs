using UnityEngine;
using UnityEngine.UI;

namespace PinBallRunner
{
    public abstract class MenuBase : MonoBehaviour
    {
        [field: SerializeField] public bool OpenByDefault { get; private set; }
        [field: SerializeField] public Button CloseButton { get; private set; }
    }
}
