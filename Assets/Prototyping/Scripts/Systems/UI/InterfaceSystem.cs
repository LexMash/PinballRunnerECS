using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Configs;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PinBallRunner.Prototyping.Scripts.Systems.UI
{
    public class InterfaceSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world;

        private readonly EcsFilter<MenuOpenRequest> _openFilter;
        private readonly EcsFilter<MenuCloseRequest> _closeFilter;

        private readonly MenuConfig _data;
        private readonly SceneData _sceneData;

        private readonly Dictionary<Type, MenuBase> _menuMap = new();
        private readonly Stack<MenuBase> _menuStack = new();

        private MenuBase _currentOpenedMenu;

        public void PreInit()
        {
            foreach (var menu in _data.Menus)
            {
                var type = menu.GetType();
                var menuGO = Object.Instantiate(menu, _sceneData.MenuContainer.ParentTransform);
                _menuMap[type] = menuGO;

                if (menuGO.OpenByDefault)
                {
                    ShowMenu(menuGO);
                    _currentOpenedMenu = menuGO;
                    _menuStack.Push(_currentOpenedMenu);
                }
                else
                {
                    HideMenu(menuGO);
                }              
            }
        
            var interfaceData = _world.NewEntity();
            interfaceData.Get<InterfaceData>().MenuMap = _menuMap;
        }

        public void Run()
        {
            HandleOpenFilter();

            HandleCloseFilter();
        }

        private void HandleOpenFilter()
        {
            foreach (var index in _openFilter)
            {
                ref var openRequest = ref _openFilter.Get1(index);
                var entity = _openFilter.GetEntity(index);

                MenuBase menu = _menuMap[openRequest.MenuType];

                _menuStack.Push(_currentOpenedMenu);

                HideMenu(_currentOpenedMenu);
                ShowMenu(menu);

                _currentOpenedMenu = menu;

                entity.Del<MenuOpenRequest>();
            }
        }

        private void HandleCloseFilter()
        {
            foreach (var index in _closeFilter)
            {
                ref var closeRequest = ref _closeFilter.GetEntity(index);

                HideMenu(_currentOpenedMenu);
                var menu = _menuStack.Pop();
                ShowMenu(menu);

                _currentOpenedMenu = menu;               

                closeRequest.Del<MenuCloseRequest>();
            }
        }

        private void ShowMenu(MenuBase menu)
        {
            if (menu == _currentOpenedMenu)
                return;

            menu.gameObject.SetActive(true);
            menu.gameObject.transform.SetAsLastSibling();         
        }

        private void HideMenu(MenuBase menu)
        {
            menu.gameObject.SetActive(false);
        }
    }
}
