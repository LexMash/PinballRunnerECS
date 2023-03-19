using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Configuration
{
    [CreateAssetMenu(fileName = "ScoreValuesConfig", menuName = "PinBallRunner/CONFIG/ScoreValuesConfig")]
    public class ScoreValuesConfig : ScriptableObject
    {
        //например
        [field: SerializeField] public int Distance { get; private set; } = 10;
        [field: SerializeField] public int Bounce { get; private set; } = 20;
        [field: SerializeField] public int Bumper { get; private set; } = 15;
        [field: SerializeField] public int Death { get; private set; } = 100;
        [field: SerializeField] public int StarCollect { get; private set; } = 50;
    }
}
