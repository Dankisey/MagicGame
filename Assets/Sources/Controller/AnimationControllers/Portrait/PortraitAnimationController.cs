using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public sealed class PortraitAnimationController : CharacterAnimationController
    {
        private const string AttackCompleted = nameof(AttackCompleted);
        private const string BattleEnded = nameof(BattleEnded);

        private MagicCombiner _magicCombiner;
        private Battle _currentBattle;
        private World _world;
        
        public void Init(Player player, World world)
        {
            _magicCombiner = player.MagicCombiner;
            _world = world;
            Init(player);
        }

        protected override void Subscribe()
        {
            _magicCombiner.AttackCompleted += OnAttackCompleted;
            _world.BattleInitiated += OnBattleInitiated;         
            base.Subscribe();
        }

        protected override void Unsubscribe()
        {
            _magicCombiner.AttackCompleted -= OnAttackCompleted;
            _world.BattleInitiated -= OnBattleInitiated;
            base.Unsubscribe();
        }

        protected override void ResetAnimator()
        {
            Animator.SetBool(BattleEnded, false);
            base.ResetAnimator();
        }

        private void OnBattleInitiated(Battle battle)
        {
            _currentBattle = battle;
            _currentBattle.Ended += OnBattleEnded;
        }

        private void OnBattleEnded()
        {
            Animator.SetBool(BattleEnded, true);
            _currentBattle.Ended -= OnBattleEnded;
        }

        private void OnAttackCompleted(Attack obj)
        {
            Animator.SetTrigger(AttackCompleted);
        }
    }
}