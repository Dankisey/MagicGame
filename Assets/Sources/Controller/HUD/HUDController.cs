using UnityEngine;
using Game.Model;

namespace Game.Conroller
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _hudCanvasGroup;
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
            ShowHUD();
        }

        private void OnPlayerTurnChanged(bool value)
        {
            ChangeHUDInteractable(value);
        }

        private void OnBattleEnded()
        {
            _currentBattle.Ended -= OnBattleEnded;
            _currentBattle.PlayerTurnChanged -= OnPlayerTurnChanged;
            Invoke(nameof(HideHUD), _secondsBeforeHideHUD);
        }

        private void ChangeHUDInteractable(bool value) 
        { 
            _hudCanvasGroup.interactable = value;
        }

        private void ShowHUD()
        {
            _hudCanvasGroup.alpha = 1;
            _hudCanvasGroup.interactable = true;
            _hudCanvasGroup.blocksRaycasts = true;
        }

        private void HideHUD()
        {
            _hudCanvasGroup.alpha = 0;
            _hudCanvasGroup.interactable = false;
            _hudCanvasGroup.blocksRaycasts = false;
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