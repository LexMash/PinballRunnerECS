using UnityEngine;

namespace PinBallRunner
{
    public class LevelSegmentView : MonoBehaviour
    {
        [field: SerializeField] public bool IsStart { get; private set; } = false;
        [field: SerializeField] public Transform Start { get; protected set; }
        [field: SerializeField] public Transform End { get; protected set; }
        [field: SerializeField] public Transform[] Collectables { get; protected set; }
        [field: SerializeField] public Transform[] Enviroments { get; protected set; }
    }
}
