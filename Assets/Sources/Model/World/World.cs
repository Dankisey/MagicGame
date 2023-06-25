using System;

namespace Game.Model
{
    public class World
    {
        private readonly Player _player;
        private Battle _currentBattle;

        public World(Player player)
        {
            _player = player;        
        }

        public event Action<Battle> BattleInitiated;

        public void InitiateBattle()
        {
            //_currentBattle = new(_player, new Enemy[1] {new Bat()});
            BattleInitiated?.Invoke(_currentBattle);

            _currentBattle.Ended += OnBattleEnded;
            _currentBattle.Enter();
        }

        private void OnBattleEnded()
        {
            _currentBattle.Ended -= OnBattleEnded;
            _currentBattle = null;

            UnityEngine.Debug.Log("Battle ended");
        }
    }

    public interface IState
    {
        public void Enter();
    }
}