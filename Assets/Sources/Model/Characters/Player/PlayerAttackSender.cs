namespace Game.Model
{
    public sealed class PlayerAttackSender : AttackSender
    {     
        private MagicCombiner _magicCombiner;

        public PlayerAttackSender(MagicCombiner magicCombiner, DamageBuffsContainer damageBuffsContainer) : base(damageBuffsContainer)
        {
            _magicCombiner = magicCombiner;
            _magicCombiner.AttackCompleted += SendAttack;
        }

        public void Disable()
        {
            _magicCombiner.AttackCompleted -= SendAttack;
        }
    }
}