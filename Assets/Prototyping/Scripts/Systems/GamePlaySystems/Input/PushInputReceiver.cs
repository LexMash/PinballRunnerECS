using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Components;
using PinBallRunner.Prototyping.Scripts.Systems.GamePlaySystems.Push;
using UnityEngine.InputSystem;

namespace PinBallRunner.Prototyping.Scripts.Systems
{
    public class PushInputReceiver : GamePlaySystem, IEcsInitSystem, IEcsDestroySystem
    {
        private readonly GameInput _input;
        private readonly EcsWorld _world;

        public void Init()
        {
            _input.PCInput.Push.performed += PushPerformed;
        }

        public void Destroy()
        {
            _input.PCInput.Push.performed -= PushPerformed;
        }

        private void PushPerformed(InputAction.CallbackContext obj)
        {
            if (!CanWork())
            {
                return;
            }
          
            _world.NewEntity().Get<PlayerPushRequest>();
        }
    }
}