using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.MonoComponents.UI
{
    public class MenuContainer : MonoBehaviour
    {
        [field:SerializeField] public Transform ParentTransform { get; private set; }
    }
}
