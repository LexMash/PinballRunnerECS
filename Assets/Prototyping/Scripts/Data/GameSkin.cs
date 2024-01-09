using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Data
{
    public class GameSkin : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Material Material { get; private set; }
    }
}
