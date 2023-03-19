using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Components;
using UnityEngine.InputSystem;

namespace PinBallRunner.Prototyping.Scripts.Systems.Input
{
    public class DashInputReceiver : GamePlaySystem, IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsWorld _world;
        private readonly GameInput _input;

        public void Init()
        {
            _input.PCInput.Dash.performed += DashPerformed;
        }

        public void Destroy()
        {
            _input.PCInput.Dash.performed -= DashPerformed;
        }

        private void DashPerformed(InputAction.CallbackContext obj)
        {
            if(!CanWork())
            {
                return;
            }

            _world.NewEntity().Get<DashRequest>();
        }
    }
}
