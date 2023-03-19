using Leopotam.Ecs;

namespace PinBallRunner.Prototyping.Scripts.Systems
{
    public abstract class GamePlaySystemBase : IEcsRunSystem
    {
        public virtual void Run()
        {
            CanWork();
        }

        protected abstract bool CanWork();
    }
}
