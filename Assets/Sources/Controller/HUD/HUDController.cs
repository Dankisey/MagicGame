using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _playerCanvas;
        [SerializeField] private CanvasGroup[] _battleCanvases;
        [SerializeField] private float _secondsBeforeHideHUD;

        private Battle _currentBattle;
        private World _world;
        private bool _subscribed = false;

        public void Init(World world)
        {
            _world = world;
            Subscribe();
        }

        private void OnBattleInitiated(Battle battle)
        {
            _currentBattle = battle;
            _currentBattle.Ended += OnBattleEnded;
            _currentBattle.PlayerTurnChanged += OnPlayerTurnChanged;
            ShowAll();
        }

        private void OnPlayerTurnChanged(bool value)
        {
            ChangeCanvasInteractable(_playerCanvas, value);
        }

        private void OnBattleEnded()
        {
            _currentBattle.Ended -= OnBattleEnded;
            _currentBattle.PlayerTurnChanged -= OnPlayerTurnChanged;
            Invoke(nameof(HideAll), _secondsBeforeHideHUD);
        }

        private void ChangeCanvasInteractable(CanvasGroup hud,bool value) 
        { 
            hud.interactable = value;
        }

        private void ShowAll()
        {
            foreach (var hud in _battleCanvases)
                ShowCanvas(hud);
        }

        private void HideAll()
        {
            foreach (var hud in _battleCanvases)
                HideCanvas(hud);
        }

        private void ShowCanvas(CanvasGroup hud)
        {
            hud.alpha = 1;
            hud.interactable = true;
            hud.blocksRaycasts = true;
        }

        private void HideCanvas(CanvasGroup hud)
        {
            hud.alpha = 0;
            hud.interactable = false;
            hud.blocksRaycasts = false;
        }

        private void Subscribe()
        {
            _world.BattleInitiated += OnBattleInitiated;
            _subscribed = true;
        }

        private void Unsubscribe()
        {
            _world.BattleInitiated -= OnBattleInitiated;
            _subscribed = false;
        }

        private void OnEnable()
        {
            if (_world != null && _subscribed == false)
                Subscribe();
        }

        private void OnDisable()
        {
            if (_world != null && _subscribed == true)
            {
                Unsubscribe();
            }
        }
    }
}