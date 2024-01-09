using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Components;
using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Systems
{
    public class DashCooldownSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DashCooldown> _filter;

        public void Run()
        {
            foreach(var index in _filter)
            {
                ref var cooldownTimer = ref _filter.Get1(index);

                cooldownTimer.Time -= Time.deltaTime;

                if(cooldownTimer.Time <= 0)
                {
                    ref var entity = ref _filter.GetEntity(index);
                    entity.Del<DashCooldown>();
                }
            }
        }
    }
}
