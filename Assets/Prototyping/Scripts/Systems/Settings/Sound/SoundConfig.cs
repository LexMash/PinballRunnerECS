using System;
using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Systems.Settings
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "PinBallRunner/CONFIG/SoundConfig")]
    public partial class SoundConfig : ScriptableObject
    {
        [SerializeField] private AudioType[] soundTypes;

        [Serializable]
        private class AudioType
        {
            public SoundType Type;
            public AudioClip Sound;
        }
    }
}
