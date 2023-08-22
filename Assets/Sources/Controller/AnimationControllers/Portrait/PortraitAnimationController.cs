using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public sealed class PortraitAnimationController : CharacterAnimationController
    {
        private const string AttackCompleted = nameof(AttackCompleted);
        private const string BattleEnded = nameof(BattleEnded);

        private MagicCombiner _magicCombiner;
        private BattleState _currentBattle;
        private World _world;
        
        public void Init(Player player, World world)
        {
            if (_world != null)
                Unsubscribe();

            _magicCombiner = player.MagicCombiner;
            _world = world;
            Init(player);
        }

        protected override void Subscribe()
        {
            base.Subscribe();
            _magicCombiner.AttackCompleted += OnAttackCompleted;
            _world.BattleInitiated += OnBattleInitiated;         
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();
            _magicCombiner.AttackCompleted -= OnAttackCompleted;
            _world.BattleInitiated -= OnBattleInitiated;
        }

        private void OnBattleInitiated(BattleState battle)
        {
            ResetAnimator();
            _currentBattle = battle;
            _currentBattle.Ended += OnBattleEnded;
        }

        private void OnBattleEnded()
        {
            Animator.SetTrigger(BattleEnded);
            _currentBattle.Ended -= OnBattleEnded;
        }

        private void OnAttackCompleted(Attack obj)
        {
            Animator.SetTrigger(AttackCompleted);
        }
    }
}