using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    public class HUDController : MonoBehaviour
    {   
        [SerializeField] private HUDPanel _mainPanel;

        private Battle _currentBattle;
        private World _world;

        public void Init(World world)
        {
            _world = world;
            _world.BattleInitiated += OnBattleInitiated;
        }

        private void OnBattleInitiated(Battle battle)
        {
            _currentBattle = battle;
            _currentBattle.Ended += OnBattleEnded;
            _currentBattle.PlayerAttackRecieved += OnPlayerAttackRecieved;
        }

        private void OnBattleEnded()
        {
            _currentBattle.Ended -= OnBattleEnded;
            _currentBattle.PlayerAttackRecieved -= OnPlayerAttackRecieved;
        }

        private void OnPlayerAttackRecieved()
        {
            _mainPanel.Open();
        }

        private void Start()
        {
            _mainPanel.Open();
        }

        private void OnEnable()
        {
            if (_world != null)
                _world.BattleInitiated += OnBattleInitiated;
        }

        private void OnDisable()
        {
            if (_world != null)
                _world.BattleInitiated -= OnBattleInitiated;
        }
    }
}