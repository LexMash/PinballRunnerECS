using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.Components;
using PinBallRunner.Prototyping.Scripts.MonoComponents.UI.Menus;
using PinBallRunner.Prototyping.Scripts.Systems.Game;
using PinBallRunner.Prototyping.Scripts.Systems.GamePlaySystems.Push;
using PinBallRunner.Prototyping.Scripts.Systems.Score;
using TMPro;
using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Systems.UI.Menus
{
    public class GamePlayHUD : MenuInitSystem<GamePlayHUDMono>, IEcsRunSystem
    {
        private readonly EcsFilter<GameScoreChangedEvent> _scoreChangedFilter;
        private readonly EcsFilter<GameScore> _gameScoreFilter;
        private TextMeshProUGUI _score;

        public void Run()
        {
            foreach(var i in _scoreChangedFilter)
            {
                foreach(var ii in _gameScoreFilter)
                {
                    ref var gameScore = ref _gameScoreFilter.Get1(ii);

                    _score.text = gameScore.Value.ToString();
                }

                ref var changedEvent = ref _scoreChangedFilter.GetEntity(i);
                changedEvent.Del<GameScoreChangedEvent>();
            }
        }

        protected override void Subscribe()
        {
            base.Subscribe();

            _menu.StartBttn.onClick.AddListener(StartBttnClicked);
            _menu.PauseBttn.onClick.AddListener(PauseBttnClicked);
            _menu.PushBttn.onClick.AddListener(PushBttnClicked);
            _menu.DashBttn.onClick.AddListener(DashBttnClicked);

            _score = _menu.Score;
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();

            _menu.StartBttn.onClick.RemoveListener(StartBttnClicked);
            _menu.PauseBttn.onClick.RemoveListener(PauseBttnClicked);
            _menu.PushBttn.onClick.RemoveListener(PushBttnClicked);
            _menu.DashBttn.onClick.RemoveListener(DashBttnClicked);
        }

        private void StartBttnClicked()
        {
            _world.NewEntity().Get<SetGamePlayStateRequest>();
            PushBttnClicked();

            _menu.StartBttn.gameObject.SetActive(false);           
        }

        private void PauseBttnClicked()
        {
            Time.timeScale = 0;
            _world.NewEntity().Get<MenuOpenRequest>().MenuType = (typeof(PauseMenuMono));
        }

        private void PushBttnClicked()
        {
            _world.NewEntity().Get<PlayerPushRequest>();
        }

        private void DashBttnClicked()
        {
            _world.NewEntity().Get<DashRequest>();
        }     
    }
}
