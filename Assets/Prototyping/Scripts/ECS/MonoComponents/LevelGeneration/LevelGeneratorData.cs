using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.MonoComponents.GameEnviroment
{
    [CreateAssetMenu(fileName = "LevelGeneratorData", menuName = "PinBallRunner/DATA/LevelGeneratorData")]
    public class LevelGeneratorData : ScriptableObject
    {
        [field:SerializeField] public LevelSegmentView StartSegment { get; private set; }
        [field:SerializeField] public LevelSegmentView[] Segments { get; private set; }
    }
}
