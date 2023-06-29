using System;

namespace Game.Model
{
    public sealed class PlayerAttackPerformer : AttackPerformer
    {
        public PlayerAttackPerformer(PlayerAttackSender attackSender, Character character) : base(attackSender, character) { }

        public event Action AttackCanceled;

        protected override bool TryAttack(Attack attack)
        {
            if (Battle.PlayerTurn)
            {
                Battle.SendPlayerAttack(attack);
                return true;
            }
            else
            {
                AttackCanceled?.Invoke();
                return false;
            }
        }
    }
}