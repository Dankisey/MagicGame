using UnityEngine.TextCore.Text;

namespace Game.Model
{
    public abstract class AttackPerformer
    {
        private readonly AttackSender _attackSender;

        public AttackPerformer(AttackSender attackSender, Character character) 
        {
            _attackSender = attackSender;
            attackSender.AttackSent += OnAttackSent;
            character.Died += OnCharacterDeath;
        }

        protected BattleState Battle;

        public void InitBattle(BattleState battle)
        {
            Battle = battle;           
        }

        protected abstract bool TryAttack(Attack attack);

        private void OnAttackSent(Attack attack)
        {
            TryAttack(attack);
        }

        private void OnCharacterDeath(Character character)
        {
            _attackSender.AttackSent -= OnAttackSent;
            character.Died -= OnCharacterDeath;
        }
    }
}