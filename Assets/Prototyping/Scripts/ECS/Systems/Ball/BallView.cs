using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Systems;
using PinBallRunner.Prototyping.Scripts.Systems.Settings;
using UnityEngine;

namespace PinBallRunner
{
    public class BallView : MonoBehaviour
    {
        [field: SerializeField] public Material Material { get; private set; }
        [HideInInspector] public EcsEntity Entity;

        private void OnCollisionEnter(Collision collision)
        {
            var force = collision.impulse.magnitude;
            //if (collision.gameObject.tag != _floorTag)
            {               
                SendRequest(force, SoundType.RegularHit);
            }

            //if (collision.gameObject.GetComponent<BouncedWall>())
            {
                SendRequest(force, SoundType.BounceHit);
            }

            //if (collision.gameObject.GetComponent<DamageWall>())
            {
                ///Damaged?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //if (other.gameObject.GetComponent<Star>())
            {
                //ScoreCollected?.Invoke();
            }

            //if (other.gameObject.GetComponent<ScoreMultiplier>())
            {
                //Multiplied?.Invoke();
            }
        }

        private void SendRequest(float force, SoundType soundType)
        {
            ref var request = ref Entity.Get<BallHitRequest>();
            request.Force = force;
            request.SoundType = soundType;
        }
    }
}
