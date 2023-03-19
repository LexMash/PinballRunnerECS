using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.MonoComponents.GameEnviroment
{
    public class BounceRamp : PinballComponent
    {
        [field: SerializeField] public Animator Animator { get; private set; }

        //может процедурно анимировать?...
    }
}
