using Leopotam.Ecs;
using UnityEngine;

namespace PinBallRunner
{
    public abstract class PinballComponent : MonoBehaviour
    {
        [field: SerializeField] public Transform FxSpawnPoint { get; private set; }
        [HideInInspector] public EcsEntity Entity;
    }
}
