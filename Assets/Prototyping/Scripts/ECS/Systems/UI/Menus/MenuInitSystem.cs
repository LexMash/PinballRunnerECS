using Leopotam.Ecs;
using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Systems.UI.Menus
{
    public abstract class MenuInitSystem<TMenu> : IEcsInitSystem, IEcsDestroySystem where TMenu : MenuBase 
    {
        protected readonly EcsWorld _world;       
        protected TMenu _menu;
        protected readonly EcsFilter<InterfaceData> _filter;

        public virtual void Init()
        {
            foreach (var index in _filter)
            {
                ref var data = ref _filter.Get1(index);
                var type = typeof(TMenu);
                _menu = (TMenu)data.MenuMap[type];
            }

            Subscribe();
        }

        public virtual void Destroy() => Unsubscribe();

        protected virtual void Subscribe()
        {
            if (_menu.CloseButton != null)
            {
                _menu.CloseButton.onClick.AddListener(CloseButtonClicked);
            }            
        }

        protected virtual void Unsubscribe()
        {
            if(_menu.CloseButton != null)
            {
                _menu.CloseButton.onClick.RemoveListener(CloseButtonClicked);
            }          
        }

        protected virtual void CloseButtonClicked() => _world.NewEntity().Get<MenuCloseRequest>();
    }
}
