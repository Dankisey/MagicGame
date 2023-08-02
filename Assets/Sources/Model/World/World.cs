using System;

namespace Game.Model
{
    public class World
    {
        private readonly Player _player;
        private BattleState _currentBattle;

        public World(Player player)
        {
            _player = player;
            ExploreState = new ExploreState();
        }

        public ExploreState ExploreState { get; private set; }

        public event Action<BattleState> BattleInitiated;

        public void Start()
        {
            ExploreState.Enter();
        }

        public void EnterBattle(BattleState battle)
        {
            _currentBattle = battle;
            _currentBattle.Entered += OnBattleStarted;
            _currentBattle.Ended += OnBattleEnded;
            _currentBattle.Enter();
        }

        private void OnBattleStarted()
        {
            ExploreState.Exit();

            BattleInitiated?.Invoke(_currentBattle);
            _player.EnterBattle(_currentBattle);
        }

        private void OnBattleEnded()
        {
            _currentBattle.Entered -= OnBattleStarted;
            _currentBattle.Ended -= OnBattleEnded;
            _currentBattle = null;

            ExploreState.Enter();
        }
    }

    public interface IState
    {
        public void Enter();
        public void Exit();
    }
}